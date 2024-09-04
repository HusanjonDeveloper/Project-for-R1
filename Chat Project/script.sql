CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Chats" (
    "Id" uniqueidentifier NOT NULL,
    "Name" nvarchar(max) NOT NULL,
    CONSTRAINT "PK_Chats" PRIMARY KEY ("Id")
);

CREATE TABLE "Users" (
    "Id" uniqueidentifier NOT NULL,
    "Name" nvarchar(max) NOT NULL,
    CONSTRAINT "PK_Users" PRIMARY KEY ("Id")
);

CREATE TABLE "ChatUser" (
    "ChatsId" uniqueidentifier NOT NULL,
    "UsersId" uniqueidentifier NOT NULL,
    CONSTRAINT "PK_ChatUser" PRIMARY KEY ("ChatsId", "UsersId"),
    CONSTRAINT "FK_ChatUser_Chats_ChatsId" FOREIGN KEY ("ChatsId") REFERENCES "Chats" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_ChatUser_Users_UsersId" FOREIGN KEY ("UsersId") REFERENCES "Users" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_ChatUser_UsersId" ON "ChatUser" ("UsersId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240824122809_AllTable', '7.0.14');

COMMIT;

