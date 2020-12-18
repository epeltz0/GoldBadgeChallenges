using System;
using System.Collections.Generic;
using BadgesRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadgeTests
{
    [TestClass]
    public class UnitTest1
    {
        private BadgesRepo _repo;
        private Badges _badges;

        [TestInitialize]
        public void Arrange()
        {
            List<string> listOfDoors = new List<string>();
            _repo = new BadgesRepo();
            _badges = new Badges(1, listOfDoors);

            _repo.AddBadgeToDictionary(_badges);
        }

        [TestMethod]
        public void ViewTest()
        {
            var x = _repo.GetBadgesDictionary();

            Assert.IsNotNull(x);
            Assert.IsTrue(x.Count > 0);
        }


    }
}
