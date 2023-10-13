using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace SimpleUnitTests.Tests
{
    public class PasswordValidatorUnitTests
    {
        [CustomFact]
        public void PasswordValidator_ValidPassword_ReturnsTrue()
        {
            // Arrange
            var password = "MyP@ssw0rd123";

            // Act
            var result = PasswordValidator.Validate(password);

            // Assert
            Assert.True(result);
        }

        [CustomFact]
        public void PasswordValidator_InvalidPassword_ReturnsFalse()
        {
            // Arrange
            var password = "password";

            // Act
            var result = PasswordValidator.Validate(password);

            // Assert
            Assert.False(result);
        }
    }

    public class CustomFactAttribute : FactAttribute
    {
        public override string Skip
        {
            get => !IsEnabled() ? "Disabled" : base.Skip;
            set => base.Skip = value;
        }

        private bool IsEnabled()
        {
            // custom logic to determine if the test should be enabled or disabled
            return true;
        }
    }

    public class PasswordValidator
    {
        public static bool Validate(string password)
        {
            // password validation
            return Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$");
        }
    }
}