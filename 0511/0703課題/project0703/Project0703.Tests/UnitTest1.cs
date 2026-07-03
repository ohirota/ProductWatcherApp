using Project0703.Models;

namespace Project0703.Tests
{
    public class ProductionLineTests
    {
        [Fact]
        public void 稼働中のラインはStatusが稼働中であること()
        {
            // Arrange
            var line = new ProductionLine
            {
                Id = 1,
                LineName = "ラインA",
                Status = LineStatus.稼働中,
                Manager = "田中"
            };

            Assert.Equal(LineStatus.稼働中, line.Status);
        }

        [Fact]
        public void ラインIDが0より大きいこと()
        {
            var line = new ProductionLine
            {
                Id = 1,
                LineName = "ラインA",
                Status = LineStatus.稼働中,
                Manager = "田中"
            };

            Assert.True(line.Id > 0);
        }

    }
}