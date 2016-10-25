namespace OneCoin.Service.Model.Entity.Payment
{
    public class EParkAccountInfo
    {
        public string Type { get { return "eparkaccountinfo"; } }

        public int Return
        { get; set; }

        public string Errmsg
        { get; set; }

        public string Username
        { get; set; }

        public string Spendmoney
        { get; set; }

        public string Balancemoney
        { get; set; }

        public string Memo
        { get; set; }

        public string Operatetime
        { get; set; }

        public override string ToString()
        {
            return string.Format("Type:{0}; iReturn:{1};username:{2};spendmoney:{3};balancemoney:{4};memo:{5};operatetime:{6};errmsg:{7}",
                Type, Return.ToString(), Username, Spendmoney, Balancemoney, Memo, Operatetime, Errmsg);
        }
    }
}
