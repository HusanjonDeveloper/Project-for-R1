namespace Chat.Api.Manager;


public class UserManager( IUnitOfWork unitOfWork, JwtManager jwtManager,
    MemoryCacheManager cacheManager, UserRepository userRepository,
    IMemoryCache memoryCache)
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    private readonly JwtManager _jwtManager = jwtManager;

    private readonly MemoryCacheManager _cacheManager = cacheManager;
    
    private readonly UserRepository _userRepository = userRepository;
    
    private readonly IMemoryCache _memoryCache = memoryCache;

    private const string Key = "users";
    
    public async Task<List<UserDto>> GetAllUsers()
    {
        var dtos = _cacheManager.GetDtos(Key);

        if (dtos is not null)
        {
            return (List<UserDto>)dtos;
        }
        
        var users = await _unitOfWork.UserRepository.GetAllUsers();

        await Set();
        
        return users.ParseToDtos();
    }

    public async Task<UserDto> GetUsrById(Guid userId)
    {
        var dtos = _cacheManager.GetDtos(Key);

        if (dtos is not null)
        {
            List<UserDto> users = (List<UserDto>)dtos;
            
            var userDto = users.SingleOrDefault( x => x.Id == userId);

            if (userDto is null)
                throw new UserNotFoundException();

            return userDto;
        }

        var user = await _unitOfWork.UserRepository.GetUserById(userId);

        await Set();
        
        return user.ParseToDto();
    }

    public async Task<UserDto> Register(CreateUserModel model)
    {
        await CheckForrExist(model.UserName);

        var user = new User()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            UserName = model.UserName,
            Gender = GetGender(model.Gender),
            Role = UserConstants.Male
        };
        
         if(user.UserName == "husan")
         {
             user.Role = UserConstants.UserRole;
         }
        
         // for any logics 
         
         /*
          *if(user.FirstName == " ")
          * {
          * user.Role == UserConstants.AdminRole;
          */
         
         
        var passwordHash = new PasswordHasher<User>()
                                .HashPassword(user, model.Password);
                           
         user.PasswordHash = passwordHash;

         await _unitOfWork.UserRepository.AddUser(user);
         return user.ParseToDto();
    }
    
    private async Task CheckForrExist(string username)
    {
         var user  =  await _unitOfWork.UserRepository.GetUserByUsername(username);

         if (user is null)
             throw new UserExsitException();
    }

    public async Task<string> Login(LoginModel model)
    {
        var user = await _unitOfWork.UserRepository.GetUserByUsername(model.UserName);
       
        if(user is null)
            throw new Exception("Invalid username");

        var result = new PasswordHasher<User>().
            VerifyHashedPassword(user, user.PasswordHash, model.Password);

        if (result == PasswordVerificationResult.Failed)
            throw new Exception("Invalid  password");


        if (string.IsNullOrEmpty(user.Role))
        {
            user.Role ??= UserConstants.UserRole;
            await _unitOfWork.UserRepository.AddUser(user);
        }
        var token = _jwtManager.GenerateToken(user);

        return token;
    }

    public async Task<byte[]> AddOrUpdatePhoto(Guid userId,IFormFile file)
    {

        var  user = await _unitOfWork.UserRepository.GetUserById(userId);

        var check = Helpers.StaticHelper.IsPhoto(file);
        
         
        if (!check)
            throw new NotPhotoType();
        
        var data = Helpers.StaticHelper.GetData(file);
        
        user.PhotoData = data;

        await Set();
        
        return data;

    }

    private string GetGender(string gender)
    {
        var checkForGenderExist = gender.ToLower() == UserConstants.Male
                                   || gender.ToLower() == UserConstants.Female;
        
        return checkForGenderExist ? gender : UserConstants.Male;
    }
    
    public async Task<UserDto> UpdateBio(Guid userId, string bio)
    {
        var user = await _unitOfWork.UserRepository.GetUserById(userId);
        if (!string.IsNullOrEmpty(bio)) {

            user.Bio = bio;
            await _unitOfWork.UserRepository.UpdateUser(user);
        }
        await Set();
        return user.ParseToDto();
    }
    
    public async Task<UserDto> UpdateUserGeneralInfo(Guid userId, UpdateUserGeneralInfo info)
    {
        var user = await _unitOfWork.UserRepository.GetUserById(userId);

        bool check = false;
        
        if (!string.IsNullOrEmpty(info.Firstname))
        {
            user.FirstName = info.Firstname;
            check = true;
        }
        
        if (!string.IsNullOrEmpty(info.Lastname))
        {
            user.LastName = info.Lastname;
            check = true;
        }
        
        if (!string.IsNullOrEmpty(info.Age))
        {
           
            try
            {
                byte age = byte.Parse(info.Age);

                user.Age = age;
                check = true;
            }
            catch (Exception e)
            {
                throw new Exception("Age must be number");
            }
        }

        if (check)
        {
            await _unitOfWork.UserRepository.UpdateUser(user);
            await Set();
        }

        return user.ParseToDto();
    }
    
    public async Task<UserDto> UpdateUsername(Guid userId,UpdateUsernameModel model )
    {
        var user = await _unitOfWork.UserRepository.GetUserById(userId);

        await CheckForExist(model.Username);

        user.UserName = model.Username;

        await _unitOfWork.UserRepository.UpdateUser(user);

        await Set();
        return user.ParseToDto();

    }

    private async Task Set()
    {
        var users = await _unitOfWork.UserRepository.GetAllUsers();
        _cacheManager.GetOrUpdateDtos(Key,users.ParseToDtos());
    }

    private async Task CheckForExist(string username)
    {
        var user = await _userRepository.GetUserByUsername(username);

        if (user is not null)
            throw new UserExsitException();
    }
    
} 