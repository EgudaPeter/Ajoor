using Ajoor.Core;
using Ajoor.DTO;
using Ajoor.Model;
using System;
using System.Collections;
using System.Linq;

namespace Ajoor.Repos
{
    public class SuperAdminRepo
    {
        static AjoEntities entities = new AjoEntities();
        public int AddSuperAdmin(SuperAdmin SuperAdmin)
        {
            var model = new cor_super_admin()
            {
                Firstname = SuperAdmin.Firstname,
                Lastname = SuperAdmin.Lastname,
                Password = SuperAdmin.Password,
                Username = SuperAdmin.Username,
                CreatedDate = SuperAdmin.CreatedDate
            };
            entities.cor_super_admin.Add(model);
            return entities.SaveChanges();
        }

        public bool DeleteSuperAdmin(int superAdminId)
        {
            var model = entities.cor_super_admin.Find(superAdminId);
            if (model != null)
            {
                entities.cor_super_admin.Remove(model);
                return true;
            }
            return false;
        }

        public void LogInUser(long ID, string Fullname)
        {
            var loginDetails = new cor_super_admin_login_log()
            {
                AdminId = ID,
                FullName = Fullname,
                LoginDate = DateTime.Now
            };
            entities.cor_super_admin_login_log.Add(loginDetails);
            entities.SaveChanges();
        }

        public int UpdateSuperAdmin(SuperAdmin SuperAdmin)
        {
            var updateModel = entities.cor_super_admin.Find(SuperAdmin.AdminId);
            if (updateModel != null)
            {
                updateModel.Firstname = SuperAdmin.Firstname;
                updateModel.Lastname = SuperAdmin.Lastname;
                updateModel.Username = SuperAdmin.Username;
                updateModel.UpdatedDate = SuperAdmin.UpdatedDate;
            }
            return entities.SaveChanges();
        }

        public SuperAdmin GetSuperAdmin(int superAdminId)
        {
            var model = entities.cor_super_admin.Find(superAdminId);
            if (model != null)
            {
                SuperAdmin SuperAdmin = new SuperAdmin()
                {
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    Username = model.Username,
                    CreatedDate = model.CreatedDate,
                    UpdatedDate = model.UpdatedDate
                };
                return SuperAdmin;
            }
            return null;
        }

        public IQueryable<cor_super_admin> GetAllRecords()
        {
            return entities.cor_super_admin;
        }

        public bool ValidateUserCredentials(string username, string password)
        {
            var user = entities.cor_super_admin.Where(x=>x.Username == username).FirstOrDefault();
            if(user != null)
            {
                var decryptedPassword = Cryptography.Decrypt(user.Password, "SuperiorInvestment#");
                if (decryptedPassword.Equals(password))
                {
                    return true;
                }
            }
            return false;
        }

        public bool DoesUsernameExist(string username)
        {
            if(!entities.cor_super_admin.Any(x=>x.Username == username))
            {
                return false;
            }
            return true;
        }

        public bool ChangePassword(string username, string newPassword)
        {
            var user = entities.cor_super_admin.Where(x => x.Username == username).FirstOrDefault();
            if(user != null)
            {
                user.Password = Cryptography.Encrypt(newPassword, "SuperiorInvestment#");
            }
            return entities.SaveChanges() > 0;
        }
    }
}
