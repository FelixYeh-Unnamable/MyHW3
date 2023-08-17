namespace MyHW3.Models
{

    public class LiveBoard
    {
        public DateTime UpdateTime { get; set; }
        public int UpdateInterval { get; set; }
        public DateTime SrcUpdateTime { get; set; }
        public int SrcUpdateInterval { get; set; }
        public string AuthorityCode { get; set; }
        public List<StationLiveBoard> StationLiveBoard { get; set; }
    }

    public class StationLiveBoard
    {

        public string StationID { get; set; }
        public Stationname StationName { get; set; }
        public string TrainNo { get; set; }
        public int Direction { get; set; }
        public string TrainTypeID { get; set; }
        public string TrainTypeCode { get; set; }
        public Traintypename TrainTypeName { get; set; }
        public string EndingStationID { get; set; }
        public Endingstationname EndingStationName { get; set; }
        public int TripLine { get; set; }
        public string Platform { get; set; }
        public string ScheduleArrivalTime { get; set; }
        public string ScheduleDepartureTime { get; set; }
        public int DelayTime { get; set; }
        public int RunningStatus { get; set; }
        public DateTime UpdateTime { get; set; }

        public class Stationname
        {
            public string Zh_tw { get; set; }
            public string En { get; set; }
        }

        public class Traintypename
        {
            public string Zh_tw { get; set; }
            public string En { get; set; }
        }

        public class Endingstationname
        {
            public string Zh_tw { get; set; }
            public string En { get; set; }
        }

    }
}
