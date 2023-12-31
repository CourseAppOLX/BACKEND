﻿namespace backendAPI.Models.Auth
{
    public class RegisterViewModel
    {

        /// <summary>
        /// Ім'я
        /// </summary>
        /// <example>Name</example>
        public string FirstName { get; set; }
        /// <summary>
        /// Прізвище
        /// </summary>
        /// <example>Surname</example>
        public string LastName { get; set; }
        /// <summary>
        /// Електронна пошта
        /// </summary>
        /// <example>brychka.p@gmail.com</example>
        public string Email { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        /// <example>Qwerty1-</example>
        public string Password { get; set; }
        /// <summary>
        /// Підтверження пароль
        /// </summary>
        /// <example>Qwerty1-</example>
        public string ConfirmPassword { get; set; }
        /// <summary>
        /// Оберіть фото користувача
        /// </summary>
        public IFormFile Image { get; set; }
    }
}
