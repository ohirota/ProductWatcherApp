
using Microsoft.AspNetCore.Mvc;
using _0511.Models;


namespace TicketApp.Controllers
{
    public class TicketController : Controller
    {
        //ダミーデータ(本来はDBから取得するイメージ)
        static List<Ticket> tickets = new List<Ticket>
        {
            new Ticket { Id = 1, Title = "ログインできない", Description = "パスワードを入力してもログインできない", Status = "未対応", CreatedAt = DateTime.Now },
            new Ticket { Id = 2, Title = "画面が崩れる", Description = "ブラウザのサイズを変えると画面が崩れる", Status = "対応中", CreatedAt = DateTime.Now },
            new Ticket { Id = 3, Title = "ボタンが押せない", Description = "送信ボタンが非活性のまま", Status = "完了", CreatedAt = DateTime.Now },
        };

        //一覧表示
        public IActionResult Index()
        {
            return View(tickets);
        }

        //新規作成画面
        public IActionResult Create()
        {
            return View();
        }

        //新規作成処理
        [HttpPost]
        public IActionResult Create(Ticket ticket)
        {
            ticket.Id = tickets.Count + 1;
            ticket.CreatedAt = DateTime.Now ;
            ticket.Status = "未対応";
            tickets.Add(ticket);
            return RedirectToAction("Index");
        }


    }
}
