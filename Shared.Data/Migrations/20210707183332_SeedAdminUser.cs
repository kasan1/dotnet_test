using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class SeedAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO Users (Id, CreatedDate, ModifiedDate, IsDeleted, LastName, FirstName, BirthDate, Identifier, Phone, Email, IsBlocked, Audience, [Password], PasswordTryCount, IsPhysical)
                VALUES ('073A48DF-BEC5-4E0A-694F-08D9416E43F2', GETDATE(), GETDATE(), 0, 'Super', 'Admin', GETDATE(), '000000000000', '87076561143', 'yerkewka@mail.ru', 0, 1, 'qnK1/Kq5ymEUtPhW22kWbvCdPJm7mU4ia3P7P1LFx+4nFhCxmo7mfB/Hz0+o5xR7mlh3o5/gh3IVbkHjNRgYqQ==', 0, 1);
  
                INSERT INTO UserRoles (Id, CreatedDate, ModifiedDate, IsDeleted, RoleId, UserId)
                VALUES ('978aa7b8-4609-4e59-afe2-a31690a500cd', GETDATE(), GETDATE(), 0, '09704848-58D2-47D4-8939-08D86FFEDB1D', '073A48DF-BEC5-4E0A-694F-08D9416E43F2');
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DELETE FROM Users WHERE Id = '073A48DF-BEC5-4E0A-694F-08D9416E43F2';
                DELETE FROM UserRoles WHERE Id = '978aa7b8-4609-4e59-afe2-a31690a500cd';
            ");
        }
    }
}
