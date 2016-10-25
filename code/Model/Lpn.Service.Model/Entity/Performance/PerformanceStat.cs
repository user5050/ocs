namespace OneCoin.Service.Model.Entity.Performance
{
    public class PerformanceStat
    {
        public string Method { get; set; }

        public double MaxRun { get; set; }

        public double TotalRun { get; set; }

        public int Cnt { get; set; }

        public int RealCnt { get; set; }
    }
}
