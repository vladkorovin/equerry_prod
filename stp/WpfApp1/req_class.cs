using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Configuration;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Media.Animation;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.Protocols;
using System.Runtime.CompilerServices;
using WpfApplication1;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using RestSharp;
using RestSharp.Deserializers;
using req_class_namespace;


namespace req_class_namespace
{

    public class User
    {
        public int ldap;
        public string fio;
        public string mail;
        public string title;

        public void GetADUserByLdap(string indentity)
        {
            SearchResult result;
           
            string ADpath = "LDAP://ru1000";
            DirectoryEntry rootEnt = new DirectoryEntry(ADpath);
            DirectorySearcher searcher = new DirectorySearcher(rootEnt);

            searcher.PropertiesToLoad.Add("cn");
            searcher.Filter = ("(SAMAccountName=" + indentity + "*)");
            result = searcher.FindOne();
                if (result == null)
                {
                    ldap = 0;
                }
                else
                {
                    ldap = Int32.Parse(indentity);
                    fio = result.GetDirectoryEntry().Properties["displayname"].Value.ToString();
                    if (result.GetDirectoryEntry().Properties["title"].Value != null)
                    {
                        title = result.GetDirectoryEntry().Properties["title"].Value.ToString();
                    }
                if (result.GetDirectoryEntry().Properties["mail"].Value != null)
                {
                    mail = result.GetDirectoryEntry().Properties["mail"].Value.ToString();
                }
            }

            

        }
    }

    public class Constants
    {
        public string info_url;
        public string creayion_url;
        public string x_api_key;
        public string authorization;
        public string login;
        public string password;
        public string db_connection_string;

        public Constants() {

            var client = new RestClient("https://vault.lmru.adeo.com/v1/auth/approle/login");
            var request = new RestRequest(Method.POST);
            request.AddHeader("postman-token", "7faec3a0-9b0b-5cbf-014c-9dbaba6f44b4");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", "{\n\t\"role_id\":\"19cf6581-765e-1d4f-1dd3-c6e6edf256b2\",\n\t\"secret_id\":\"d20e02ac-8b5c-6fe8-09da-289c6394a7c3\"\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            vaultClass vault = JsonConvert.DeserializeObject<vaultClass>(response.Content);

           
            client = new RestClient("https://vault.lmru.adeo.com/v1/LM-HQ%20L1/EQUERRY_TEST");
            request = new RestRequest(Method.GET);
            request.AddHeader("postman-token", "1556c450-1669-8c0b-254a-71c402ed9ed0");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("x-vault-token", vault.auth.client_token);
            response = client.Execute(request);

            vaultSecret secret = JsonConvert.DeserializeObject<vaultSecret>(response.Content);
           

            info_url = secret.data.info_url;
            creayion_url = secret.data.creation_url;
            x_api_key = secret.data.x_api_key;
            authorization = secret.data.authorization;
            login = secret.data.login;
            password = secret.data.password;
            db_connection_string = secret.data.db_connection_string;
        }
        
  
    };
    

   
    public class req_class
    {
        public string CaseNumber { get; set; }
        public string CaseId { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string Contact { get; set; }
        public string ContactId { get; set; }
        public string ContactLogin { get; set; }
        public string ContactServicePact { get; set; }
        public string ContactServicePactName { get; set; }
        public string Shop { get; set; }
        public string Email { get; set; }
        public string BP { get; set; }
        public string BS { get; set; }
        public string ServiceItem { get; set; }
        public string TS { get; set; }
        public string Urgency { get; set; }
        public string Impact { get; set; }
        public string GroupName { get; set; }
        public string OwnerName { get; set; }
        public string ShortDesc { get; set; }
        public string Description { get; set; }
        public string TechDesc { get; set; }
        public string SourceName { get; set; }
        public string Major { get; set; }
        public string ExtNumber { get; set; }
        public string RegisteredDate { get; set; }
        public string FirstSaveDate { get; set; }
        public string ResponseDate { get; set; }
        public string RespondedOnDate { get; set; }
        public string SolutionDate { get; set; }
        public string SolutionProvidedOnDate { get; set; }
        public string ClosureDate { get; set; }
        public string CreateGroupName { get; set; }
        public string CreatedByName { get; set; }
        public string Solution { get; set; }
        public string RootCause { get; set; }
        public string ClosureCode { get; set; }
        public string SolutionType { get; set; }
        public string TechResolution { get; set; }
        public string SatisfactionLevel { get; set; }
        public string SatisfactionLevelComment { get; set; }
        public string UsrNeedClassifyML { get; set; }

        public int pr;

        public req_class(string BP, string BS, string ServiceItem, string Contact, string ShortDescr, string Description, int Priority)
        {
            this.BP = BP;
            this.BS = BS;
            this.ServiceItem = ServiceItem;
            this.Contact = Contact;
            this.ShortDesc = ShortDescr;
            this.Description = Description;
            this.pr = Priority;
        }

        public req_class()
        {

        }

        public bool create_req(int Priority)
        {

            Constants constants = new Constants();

            DateTime t1 = new DateTime();
            t1 = DateTime.Now;

            var client = new RestClient(constants.creayion_url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("password", constants.password);
            request.AddHeader("login", constants.login);
            request.AddHeader("x-api-key", constants.x_api_key);
            string data = "{\n\t\"Action\":\"Create\",\n\t\"Title\":\"" + this.ShortDesc + "\",\n\t\"Description\":\"" + this.Description + "\",\n\t\"BP\":\"" + this.BP + "\",\n\t\"BS\":\"" + this.BS + "\",\n\t\"ServiceItem\":\"" + this.ServiceItem + "\",\n\t\"Contact\":\"" + this.Contact + "\"\n}";
            request.AddParameter("application/json", data, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            
            Regex regex = new Regex("[A-Z]{3}[0-9]{6}_[0-9]{4}");
            MatchCollection matchCollection = regex.Matches(response.Content.ToString());


            client = new RestClient(constants.info_url);
            request = new RestRequest(Method.POST);
            request.AddHeader("postman-token", "d3a81b68-caad-ff47-3c61-d6771687a3de");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("x-api-key", constants.x_api_key);
            request.AddHeader("authorization", "Basic " + constants.authorization);
            request.AddHeader("content-type", "application/json; charset=utf-8");
            request.AddParameter("application/json; charset=utf-8", "{\n\t\"Action\":\"Info\",\n\t\"CaseNumber\": \"" + matchCollection[0] + "\"\n}", ParameterType.RequestBody);
            response = client.Execute(request);

            DateTime t2 = new DateTime();
            t2 = DateTime.Now;

            MessageBox.Show((t2.Second - t1.Second).ToString());

            req_class created_req = new req_class();
            regex = new Regex(@"\{\""CaseNumber"":.+?\}");
            matchCollection = regex.Matches(response.Content);
            created_req = JsonConvert.DeserializeObject<req_class>(matchCollection[0].ToString());

            this.Description = created_req.Description;
            this.Email = created_req.Email;
            this.ExtNumber = created_req.ExtNumber;
            this.BP = created_req.BP;
            this.BS = created_req.BS;
            this.CaseId = created_req.CaseId;
            this.CaseNumber = created_req.CaseNumber;
            this.ClosureCode = created_req.ClosureCode;
            this.ClosureDate = created_req.ClosureDate;
            this.Contact = created_req.Contact;
            this.ContactId = created_req.ContactId;
            this.ContactLogin = created_req.ContactLogin;
            this.ContactServicePact = created_req.ContactServicePact;
            this.ContactServicePactName = created_req.ContactServicePactName;
            this.CreatedByName = created_req.CreatedByName;
            this.CreateGroupName = created_req.CreateGroupName;
            this.FirstSaveDate = created_req.FirstSaveDate;
            this.GroupName = created_req.GroupName;
            this.Impact = created_req.Impact;
            this.Major = created_req.Major;
            this.OwnerName = created_req.OwnerName;
            this.Priority = created_req.Priority;
            this.RegisteredDate = created_req.RegisteredDate;
            this.RespondedOnDate = created_req.RespondedOnDate;
            this.ResponseDate = created_req.ResponseDate;
            this.RootCause = created_req.RootCause;
            this.SatisfactionLevel = created_req.SatisfactionLevel;
            this.SatisfactionLevelComment = created_req.SatisfactionLevelComment;
            this.ServiceItem = created_req.ServiceItem;
            this.Shop = created_req.Shop;
            this.ShortDesc = created_req.ShortDesc;
            this.Solution = created_req.Solution;
            this.SolutionDate = created_req.SolutionDate;
            this.SolutionProvidedOnDate = created_req.SolutionProvidedOnDate;
            this.SolutionType = created_req.SolutionType;
            this.SourceName = created_req.SourceName;
            this.Status = created_req.Status;
            this.TechDesc = created_req.TechDesc;
            this.TechResolution = created_req.TechResolution;
            this.TS = created_req.TS;
            this.Urgency = created_req.Urgency;
            this.UsrNeedClassifyML = created_req.UsrNeedClassifyML;

            db_request db_Request = new db_request(created_req, Priority, false);
                     
            return true;

        }

    }




    public class db_request {
        public Constants constants;
        public string request_number { get; set; }
        public string request_id { get; set; }
        public string contact { get; set; }
        public string status { get; set; }
        public DateTime creation_date { get; set; }
        public DateTime solution_date { get; set; }
        public int priority { get; set; }
        public int stp_ldap { get; set; }
        public bool flag { get; set; }
        public int window { get; set; }

        public bool change_status { get; set; }
        public bool need_creation { get; set; }

       

        public db_request(req_class req, int priority, bool flag) {
            request_number = req.CaseNumber;
            request_id = req.CaseId;
            contact = req.Contact;
            status = "В очереди";
            creation_date = DateTime.Now;
            solution_date = DateTime.MaxValue;
            this.priority = priority;
            stp_ldap = 0;
            this.flag = flag;
            window = 0;
            constants = new Constants();
        }

        public db_request() { }
    
    }
  
}
