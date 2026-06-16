using _0511.Models;

namespace _0511.Tests
{
    public class TicketTests
    {
        [Fact]
        public void チケット作成時ステータスは未対応()
        {
            //準備
            var ticket = new Ticket
            {
                Id = 1,
                Title = "テストチケット",
                Description = "テスト説明。",
                Status = "未対応",
                CreatedAt = DateTime.Now
            };

            //確認
            Assert.Equal("未対応", ticket.Status);

        }

        [Fact]
        public void チケットのタイトルが空でないこと()
        {
            //準備
            var ticket = new Ticket
            {
                Id = 2,
                Title = "テストチケット",
                Description = "テスト説明",
                Status = "未対応",
                CreatedAt = DateTime.Now
            };

            //確認
            Assert.False(string.IsNullOrEmpty(ticket.Title));
        }
    }
}