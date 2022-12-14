using MapJSON.Data.Context;
using MapJSON.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapJSON.Data.Repositories
{
    public interface IAppUserRepository 
    {
        void AddAppUser(AppUser appUser);

        List<AppUser> GetUsers();

        List<AppUser> GetUsersByTheme(string themeName);

        void UpdateUserTheme(Guid userId, Theme theme);

        void UpdateUserSettings(Guid userId, UserSettings userSettings);
    }
    public class AppUserRepository : IAppUserRepository
    {
        private readonly MapJSONContext _context;

        public AppUserRepository(MapJSONContext context) 
        {
            _context = context;
        }

        public void AddAppUser(AppUser appUser) 
        { 
            _context.AppUsers.Add(appUser);
            _context.SaveChanges();
        }

        public List<AppUser> GetUsers() 
        { 
            return _context.AppUsers.ToList();
        }

        public List<AppUser> GetUsersByTheme(string themeName) 
        { 
            return _context.AppUsers.Where(u => u.UserSettings != null && u.UserSettings.Theme.Name.ToLower() == themeName.ToLower()).ToList();
        }

        public void UpdateUserTheme(Guid userId, Theme theme) 
        {
            AppUser appUser = _context.AppUsers.FirstOrDefault(u => u.Id == userId);

            if (appUser != null)
            {
                appUser.UserSettings.Theme = theme;
                _context.SaveChanges();
            }
        }

        public void UpdateUserSettings(Guid userId, UserSettings userSettings)
        {
            AppUser appUser = _context.AppUsers.FirstOrDefault(u => u.Id == userId);

            if (appUser != null)
            {
                appUser.UserSettings = userSettings;
                _context.SaveChanges();
            }
        }
    }
}
