using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AccountService.Core.Models.Entities
{
    [Table("ONESOURCE_USER")]
    public class User
    {
        [Key]
        public int USER_ID { get; set; }
        public int LOCATION_ID { get; set; }
        public int ROLE_ID { get; set; }
        public string EMAIL_ADDRESS { get; set; }
        public int LANG_ID { get; set; }
        public Nullable<int> DEPT_ID { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public Nullable<System.DateTime> LAST_UPDATE_DATE { get; set; }
        public Nullable<bool> IS_ACTIVE { get; set; }
        public string NAME_TITLE { get; set; }
        public string FIRST_NAME { get; set; }
        public string MIDDLE_INITIAL { get; set; }
        public string LAST_NAME { get; set; }
        public string NAME_SUFFIX { get; set; }
        public string USER_PASSWORD { get; set; }
        public bool PWD_FORCED_CHANGE_REQUIRED { get; set; }
        public string LOGIN_NAME { get; set; }
        public string OFFICE_PHONE { get; set; }
        public string OFFICE_FAX { get; set; }
        public string CELL_PHONE { get; set; }
        public int COUNTRY_ID { get; set; }
        public string EMP_ID { get; set; }
        public string JOB_TITLE { get; set; }
        public string JPEG_PHOTO { get; set; }
        public string LAST_UPDATED_BY { get; set; }
        public Nullable<bool> IS_SUPERADMIN { get; set; }
        public Nullable<bool> IS_SERVICE_CALL_NOTIFICATION_REQD { get; set; }
        public Nullable<int> FAILED_LOGIN_COUNT { get; set; }
        public Nullable<bool> HIDE_SERVICE_DATA_TAB { get; set; }
        public string Department { get; set; }
        public System.DateTime LAST_PWD_CHANGE { get; set; }
        public System.DateTime PWD_EXPIRY_DATE { get; set; }
        public Nullable<System.DateTime> LAST_AVATAR_UPDATE_TIME { get; set; }
        public string HIGHEST_REQUEST_SERVICE_VERSION { get; set; }
        public string LAST_LOGIN_LANGUAGE_CODE { get; set; }
        public Nullable<bool> IS_APPROVED { get; set; }
        public bool IS_TEST_ACCOUNT { get; set; }
        public string DATA_SOURCE_APP { get; set; }
    }
}
