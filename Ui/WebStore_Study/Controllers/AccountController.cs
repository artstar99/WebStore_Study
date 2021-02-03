using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using WebStore_Study.Domain.Entities;
using WebStore_Study.Interfaces.Services;
using WebStore_Study.Domain.ViewModels;

namespace WebStore_Study.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly ICartService cartService;
        private readonly ILogger<AccountController> logger;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ICartService cartService, ILogger<AccountController> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.cartService = cartService;
            this.logger = logger;
        }

        #region Вход в систему

        [AllowAnonymous]
        public IActionResult Login(string ReturnUrl)
        {

            if (ReturnUrl == null)
            {

                var localUrl = Request.Headers["Referer"].ToString().Replace("http://localhost:63874", "");
                return View(new LoginViewModel { ReturnUrl = localUrl });
            }

            return View(new LoginViewModel { ReturnUrl = ReturnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            using (logger.BeginScope("Вход пользователя в систему"))
            {
                logger.LogInformation("Вход пользователя{0} в систему", model.Email);

                var loginResult = await signInManager.PasswordSignInAsync(
                    model.Email,
                    model.Password,
                    model.RememberMe,
#if DEBUG
                false
#else
                true
#endif
                );

                if (loginResult.Succeeded)
                {
                    logger.LogInformation("Вход пользователя {0} в систему успешно выполнен", model.Email);
                    if (Url.IsLocalUrl(model.ReturnUrl))
                        return Redirect(model.ReturnUrl);
                    return RedirectToAction("Index", "Home");
                }

                logger.LogWarning("Неверное имя пользователя или пароль.\nВведенный E-mail: {0}", model.Email);


                ModelState.AddModelError("", "Неверное имя пользователя или пароль");
            }
            return View(model);
        }
        #endregion

        #region Регистрация
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            logger.LogInformation("Регистрация нового пользователя {0}", model.Email);
            using (logger.BeginScope("Регистрация пользователя {0}", model.Email))
            {
                var user = new User
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Age = model.Age,
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    logger.LogInformation("Пользователь {0} зарегистрирован", user.UserName);
                    await userManager.AddToRoleAsync(user, Role.User);
                    logger.LogInformation("Пользователю {0} назначена роль {1}", user.UserName, Role.User);

                    await signInManager.SignInAsync(user, true);
                    logger.LogInformation("Пользователь {0} автоматически вошел в систему после регистрации", user.UserName);

                    return RedirectToAction("Index", "Home");
                }

                logger.LogWarning("Ошибка при регистрации нового пользователя {0}:\n{1}", string.Join(",", result.Errors.Select(e => e.Description)));

                foreach (var error in result.Errors)
                    ModelState.AddModelError($"{error.Code}", error.Description);

            }
            return View(model);
        }
        #endregion

        #region Выход из системы
        public async Task<IActionResult> Logout()
        {
            var userName = User.Identity!.Name;
            await signInManager.SignOutAsync();

            logger.LogInformation("Пользователь {0} вышел из системы", userName);

            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Отказано в доступе
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            logger.LogWarning("Отказано в доступе к {0}", Request.Path);

            return View();
        } 
        #endregion

    }
}
