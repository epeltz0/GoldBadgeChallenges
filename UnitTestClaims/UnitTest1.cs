using System;
using ClaimsRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestClaims
{
    [TestClass]
    public class UnitTest1
    {
        private ClaimsRepo _repo;
        private Claims _claims;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimsRepo();
            _claims = new Claims(1, ClaimType.Car, "crash", 100.00m, DateTime.Parse("10/20/2020"), DateTime.Parse("10/27/2020"), true);

            _repo.AddClaimToList(_claims);
        }

        [TestMethod]
        public void AddTest()
        {

            Claims claim = new Claims();
            claim.ClaimID = 1;
            ClaimsRepo repository = new ClaimsRepo();

            repository.AddClaimToList(claim);
            Claims claimFromDirectory = repository.GetClaimByID(1);

            Assert.IsNotNull(claimFromDirectory);
        }

        [TestMethod]
        public void ViewTest()
        {
            var x = _repo.ViewAllClaims();

            Assert.IsNotNull(x);
            Assert.IsTrue(x.Count > 0);
        }

    }
}
