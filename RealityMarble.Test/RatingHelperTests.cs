using System;
using NUnit.Framework;
using RealityMarble.BLL.Helpers;
using Moq;
using RealityMarble.DAL.Interfaces;
using RealityMarble.DAL.Entities;
using System.Collections.Generic;

namespace RealityMarble.Test
{
    [TestFixture]
    public class RatingHelperTests
    {
        [Test]
        public void UserAlreadyRated_UserThatNotVote_ReturnFalse()
        {
            //arrange
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(x => x.Ratings.GetAll()).Returns(new List<Rating> { new Rating { Id = 1, ImageId = 1, UserId = 2, Value = 10 } });
            RatingHelper ratingHelper = new RatingHelper(mock.Object);
            //assert
            Assert.False(ratingHelper.UserAlreadyRated(1, 1));
        }
        [Test]
        public void UpdateRating_NoVotes_ReturnsZero()
        {
            //arrange
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(x => x.Ratings.GetAll()).Returns(new List<Rating> { });
            mock.Setup(x => x.Images.Get(1)).Returns( new Image { Id = 1, About="about", Author="author", Path ="path", UserId = 1 } );
            RatingHelper ratingHelper = new RatingHelper(mock.Object);
            var image = mock.Object.Images.Get(1);                           
            //act
            ratingHelper.UpdateImageRatingAsync(1);
            //assert
            Assert.AreEqual(0, image.Rating);
        }
        [Test]
        public void UpdateRating_TwoVotes10and8_Returns9()
        {
            //arrange
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(x => x.Ratings.GetAll()).Returns(new List<Rating> {
                new Rating { Id = 1, ImageId = 1, UserId = 2, Value = 10 },
                new Rating { Id = 2, ImageId = 1, UserId = 1, Value = 8 }
            });
            mock.Setup(x => x.Images.Get(1)).Returns(new Image { Id = 1, About = "about", Author = "author", Path = "path", UserId = 1 });
            RatingHelper ratingHelper = new RatingHelper(mock.Object);
            var image = mock.Object.Images.Get(1);
            //act
            ratingHelper.UpdateImageRatingAsync(1);
            //assert
            Assert.AreEqual(9, image.Rating);
        }
    }
}
