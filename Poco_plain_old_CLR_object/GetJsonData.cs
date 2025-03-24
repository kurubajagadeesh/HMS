namespace Repo_Inpatient_Care.GenericUtilitys
{
    public  class GetJsonData
    {
        public string applicationUrl { get; set; }
        public string adminURL { get; set; }
        public string doctorURL { get; set; }
        public string patientURL { get; set; }

        public LoginConfig adminloginConfig { get; set; }
        public LoginConfig doctorloginConfig { get; set; }
        public LoginConfig patientloginConfig { get; set; }
    }
}