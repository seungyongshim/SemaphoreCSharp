using System;
using System.Threading;
using FluentAssertions;
using Xunit;

namespace SemaphoreLockguard.Tests
{
    public class SemaphoreLockguardSpec
    {
        [Fact]
        public void Should_Be_Create_Semaphore_One()
        {
            // Arrange
            var sema = new Semaphore(1, 1);

            // Act
            using (var semalock = new SemaphoreLockguard(sema, TimeSpan.FromSeconds(1)))
            {
                // Assert
                semalock.IsGotOne.Should().BeTrue();
            }
        }

        [Fact]
        public void Should_Be_Create_Semaphore_More_Than_One_False()
        {
            // Arrange
            var sema = new Semaphore(1, 1);
            sema.WaitOne();

            // Act
            using (var semalock = new SemaphoreLockguard(sema, TimeSpan.FromSeconds(1)))
            {
                // Assert
                semalock.IsGotOne.Should().BeFalse();
            }
        }
    }
}
