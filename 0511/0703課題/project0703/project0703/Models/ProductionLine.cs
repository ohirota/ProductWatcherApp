namespace Project0703.Models　　　　　//Project0703.Modelsの要素がある大きな情報の箱である
{
    public class ProductionLine　　　//ProductionLineクラスの箱がある
    {
        public int Id { get; set; }　　　　　　//Id、LineName、Status、Managerの定義の情報がある　つなぐための箱があると思ってる
        public string LineName { get; set; }
        public LineStatus Status { get; set; }
        public string Manager { get; set; }
        // コンストラクタ   
    }
    public enum LineStatus　　　　　　　　　　//LineStatus Status定義の情報の箱　上から順に入っていくイメージ
    {
        稼働中,
        停止,
        メンテナンス
    }
}
