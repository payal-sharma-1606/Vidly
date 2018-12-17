namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6b5748a0-1378-4ee4-9385-f0e09148dd83', N'guest@vidly.com', 0, N'AEdoHFdMk7K63tj1SRoDkvaTUEfX/VN2KKIBxp8/4b44hKiJI25AeBm6nyZNlffWcA==', N'eef4209a-5a4e-4757-b28c-c4a18ba86b57', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9f1afde8-14fa-4a0c-ad6f-f035685068d1', N'admin@vidly.com', 0, N'AGSVwGQgyEtSqJY3wLMY0Sk5htaFmOAwSeEb3YvgyAZGt9dB8axFVHCu8VZ/Lqqs5A==', N'310efccd-7a70-4704-b198-90089d06d699', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'bba48702-6dab-45ce-bae1-27a1b69e3ecb', N'CanManageMovies')
                
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9f1afde8-14fa-4a0c-ad6f-f035685068d1', N'bba48702-6dab-45ce-bae1-27a1b69e3ecb')

                ");
        }

        public override void Down()
        {
        }
    }
}
