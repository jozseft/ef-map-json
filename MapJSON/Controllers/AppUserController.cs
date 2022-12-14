using MapJSON.Data.Entities;
using MapJSON.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MapJSON.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserRepository _appUserRepository;

        public AppUserController(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        [HttpPost]
        public void AddAppUser() 
        {
            AppUser appUser = new AppUser
            {
                Id = Guid.NewGuid(),
                FirstName = "F1",
                LastName = "L1",
                UserSettings = new()
                {
                    Language = "ro",
                    Theme = new Theme { Name = "Dark", FontSize = 16 },
                    Tables = new List<TableDisplayedColumns>
                    {
                        new TableDisplayedColumns
                        {
                            Table = "Users",
                            Columns = new List<TableColumn>
                            {
                                new TableColumn { Name = "FirstName", DefaultValue = null, SortDirection = "asc"  },
                                new TableColumn { Name = "LastName", DefaultValue = null, SortDirection = null  }
                            }
                        },
                        new TableDisplayedColumns
                        {
                            Table = "Books",
                            Columns = new List<TableColumn>
                            {
                                new TableColumn { Name = "Name", DefaultValue = null, SortDirection = "asc"  },
                                new TableColumn { Name = "PublishingYear", DefaultValue = "2022", SortDirection = null  }
                            }
                        }
                    }
                }
            };

            _appUserRepository.AddAppUser(appUser);
        }

        [HttpGet]
        public List<AppUser> GetUsers() 
        { 
            return _appUserRepository.GetUsers();
        }

        [HttpGet]
        [Route("GetUsersByTheme")]
        public List<AppUser> GetUsersByTheme(string themeName) 
        { 
             return _appUserRepository.GetUsersByTheme(themeName);
        }

        [HttpPost]
        [Route("UpdateUserTheme")]
        public void UpdateUserTheme()
        {
            Guid userId = Guid.Parse("EC16EA91-EE2B-4D3B-9425-EB2EA58A41A1");
            Theme theme = new Theme {  Name = "Light", FontSize = 16 };

            _appUserRepository.UpdateUserTheme(userId, theme);
        }

        [HttpPost]
        [Route("UpdateUserSettings")]
        public void UpdateUserSettings()
        {
            Guid userId = Guid.Parse("EC16EA91-EE2B-4D3B-9425-EB2EA58A41A1");
            UserSettings userSettings = new UserSettings
            {
                Language = "ro",
                Theme = new Theme { Name = "Dark", FontSize = 16 },
                Tables = new List<TableDisplayedColumns>
                    {
                        new TableDisplayedColumns
                        {
                            Table = "Books",
                            Columns = new List<TableColumn>
                            {
                                new TableColumn { Name = "Name", DefaultValue = null, SortDirection = "asc"  },
                                new TableColumn { Name = "PublishingYear", DefaultValue = "2022", SortDirection = null  }
                            }
                        }
                    }
            };

            _appUserRepository.UpdateUserSettings(userId, userSettings);
        }
    }
}
