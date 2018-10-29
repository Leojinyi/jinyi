using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DapperEx;

namespace MiniAppApis.MiniAppModel
{

    [Serializable]
    [Table(Name = "goods_picture")]
    /// <summary>
    ///Info_goods_picture
    /// </summary>
    public partial class Info_goods_picture
    {
        #region 构造函数
        public Info_goods_picture() { }

        public Info_goods_picture(Int32 id, DateTime create_time, DateTime update_time, Int32 goods_id, Int32 goods_specifications_id, Int32 goods_sort_id, Byte is_default, String picture_url, String picture_file_name, String picture_describe, Byte picture_type, Int32 picture_range)
        {
            this.id = id;
            this.create_time = create_time;
            this.update_time = update_time;
            this.goods_id = goods_id;
            this.goods_specifications_id = goods_specifications_id;
            this.goods_sort_id = goods_sort_id;
            this.is_default = is_default;
            this.picture_url = picture_url;
            this.picture_file_name = picture_file_name;
            this.picture_describe = picture_describe;
            this.picture_type = picture_type;
            this.picture_range = picture_range;
        }
        #endregion

        #region 属性

        private Int32 id;

        /// <summary>
        /// 
        /// </summary>
        [Id]
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime? create_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Create_time
        {
            get { return create_time; }
            set { create_time = value; }
        }

        private DateTime? update_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Update_time
        {
            get { return update_time; }
            set { update_time = value; }
        }

        private Int32 goods_id;

        /// <summary>
        /// 商品ID
        /// </summary>
        public Int32 Goods_id
        {
            get { return goods_id; }
            set { goods_id = value; }
        }

        private Int32 goods_specifications_id;

        /// <summary>
        /// 
        /// </summary>
        public Int32 Goods_specifications_id
        {
            get { return goods_specifications_id; }
            set { goods_specifications_id = value; }
        }

        private Int32 goods_sort_id;

        /// <summary>
        /// 
        /// </summary>
        public Int32 Goods_sort_id
        {
            get { return goods_sort_id; }
            set { goods_sort_id = value; }
        }

        private Byte is_default;

        /// <summary>
        /// 
        /// </summary>
        public Byte Is_default
        {
            get { return is_default; }
            set { is_default = value; }
        }

        private String picture_url;

        /// <summary>
        /// 
        /// </summary>
        public String Picture_url
        {
            get { return picture_url; }
            set { picture_url = value; }
        }

        private String picture_file_name;

        /// <summary>
        /// 
        /// </summary>
        public String Picture_file_name
        {
            get { return picture_file_name; }
            set { picture_file_name = value; }
        }

        private String picture_describe;

        /// <summary>
        /// 
        /// </summary>
        public String Picture_describe
        {
            get { return picture_describe; }
            set { picture_describe = value; }
        }

        private Byte picture_type;

        /// <summary>
        /// 
        /// </summary>
        public Byte Picture_type
        {
            get { return picture_type; }
            set { picture_type = value; }
        }

        private Int32 picture_range;

        /// <summary>
        /// 
        /// </summary>
        public Int32 Picture_range
        {
            get { return picture_range; }
            set { picture_range = value; }
        }
        #endregion

        #region 验证
        public List<string> ErrorList = new List<string>();
        private bool Validator()
        {
            bool validatorResult = true;
            if (this.Create_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Create_time should not be empty!");
            }
            if (this.Update_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Update_time should not be empty!");
            }
            if (this.Picture_url != null && 200 < this.Picture_url.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Picture_url should not be greater then 200!");
            }
            if (this.Picture_file_name != null && 32 < this.Picture_file_name.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Picture_file_name should not be greater then 32!");
            }
            if (this.Picture_describe != null && 32 < this.Picture_describe.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Picture_describe should not be greater then 32!");
            }
            return validatorResult;
        }

        #endregion

        #region 辅助方法
        public Info_goods_picture Clone(bool isDeepCopy)
        {
            Info_goods_picture footman;
            if (isDeepCopy)
            {
                MemoryStream memoryStream = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                footman = (Info_goods_picture)formatter.Deserialize(memoryStream);
            }
            else
            {
                footman = (Info_goods_picture)this.MemberwiseClone();
            }
            return footman;
        }
        #endregion

    }


    [Serializable]
    [Table(Name = "user_extra")]
    /// <summary>
    ///Info_user_extra
    /// </summary>
    public partial class Info_user_extra
    {
        #region 构造函数
        public Info_user_extra() { }

        public Info_user_extra(Int32 id, DateTime create_time, DateTime update_time, Int32 user_id, String telephone, String mobile_number, String email, String idcard_number, String birthday, Int32 birthday_year, Int32 birthday_month, Int32 birthday_day, String name)
        {
            this.id = id;
            this.create_time = create_time;
            this.update_time = update_time;
            this.user_id = user_id;
            this.telephone = telephone;
            this.mobile_number = mobile_number;
            this.email = email;
            this.idcard_number = idcard_number;
            this.birthday = birthday;
            this.birthday_year = birthday_year;
            this.birthday_month = birthday_month;
            this.birthday_day = birthday_day;
            this.name = name;
        }
        #endregion

        #region 属性

        private Int32 id;

        /// <summary>
        /// 
        /// </summary>
        [Id]
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime? create_time;

        /// <summary>
        /// yonghuzhubiaowaijian
        /// </summary>
        public DateTime? Create_time
        {
            get { return create_time; }
            set { create_time = value; }
        }

        private DateTime? update_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Update_time
        {
            get { return update_time; }
            set { update_time = value; }
        }

        private Int32 user_id;

        /// <summary>
        /// 
        /// </summary>
        public Int32 User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }

        private String telephone;

        /// <summary>
        /// 
        /// </summary>
        public String Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }

        private String mobile_number;

        /// <summary>
        /// 
        /// </summary>
        public String Mobile_number
        {
            get { return mobile_number; }
            set { mobile_number = value; }
        }

        private String email;

        /// <summary>
        /// 
        /// </summary>
        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        private String idcard_number;

        /// <summary>
        /// 
        /// </summary>
        public String Idcard_number
        {
            get { return idcard_number; }
            set { idcard_number = value; }
        }

        private String birthday;

        /// <summary>
        /// 
        /// </summary>
        public String Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        private Int32 birthday_year;

        /// <summary>
        /// 
        /// </summary>
        public Int32 Birthday_year
        {
            get { return birthday_year; }
            set { birthday_year = value; }
        }

        private Int32 birthday_month;

        /// <summary>
        /// 
        /// </summary>
        public Int32 Birthday_month
        {
            get { return birthday_month; }
            set { birthday_month = value; }
        }

        private Int32 birthday_day;

        /// <summary>
        /// 
        /// </summary>
        public Int32 Birthday_day
        {
            get { return birthday_day; }
            set { birthday_day = value; }
        }

        private String name;

        /// <summary>
        /// 
        /// </summary>
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        #endregion

        #region 验证
        public List<string> ErrorList = new List<string>();
        private bool Validator()
        {
            bool validatorResult = true;
            if (this.Create_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Create_time should not be empty!");
            }
            if (this.Update_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Update_time should not be empty!");
            }
            if (this.Telephone != null && 20 < this.Telephone.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Telephone should not be greater then 20!");
            }
            if (this.Mobile_number != null && 11 < this.Mobile_number.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Mobile_number should not be greater then 11!");
            }
            if (this.Email != null && 50 < this.Email.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Email should not be greater then 50!");
            }
            if (this.Idcard_number != null && 18 < this.Idcard_number.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Idcard_number should not be greater then 18!");
            }
            if (this.Birthday != null && 10 < this.Birthday.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Birthday should not be greater then 10!");
            }
            if (this.Name != null && 50 < this.Name.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Name should not be greater then 50!");
            }
            return validatorResult;
        }

        #endregion

        #region 辅助方法
        public Info_user_extra Clone(bool isDeepCopy)
        {
            Info_user_extra footman;
            if (isDeepCopy)
            {
                MemoryStream memoryStream = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                footman = (Info_user_extra)formatter.Deserialize(memoryStream);
            }
            else
            {
                footman = (Info_user_extra)this.MemberwiseClone();
            }
            return footman;
        }
        #endregion

    }


    [Serializable]
    [Table(Name = "account")]
    /// <summary>
    ///Info_account
    /// </summary>
    public partial class Info_account
    {
        #region 构造函数
        public Info_account() { }

        public Info_account(Int32 id, DateTime create_time, DateTime update_time, Decimal balance, Decimal cash, Decimal freezing_amount, Int32 user_id)
        {
            this.id = id;
            this.create_time = create_time;
            this.update_time = update_time;
            this.balance = balance;
            this.cash = cash;
            this.freezing_amount = freezing_amount;
            this.user_id = user_id;
        }
        #endregion

        #region 属性

        private Int32 id;

        /// <summary>
        /// 
        /// </summary>
        [Id]
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime? create_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Create_time
        {
            get { return create_time; }
            set { create_time = value; }
        }

        private DateTime? update_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Update_time
        {
            get { return update_time; }
            set { update_time = value; }
        }

        private Decimal balance;

        /// <summary>
        /// 
        /// </summary>
        public Decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        private Decimal cash;

        /// <summary>
        /// 
        /// </summary>
        public Decimal Cash
        {
            get { return cash; }
            set { cash = value; }
        }

        private Decimal freezing_amount;

        /// <summary>
        /// 
        /// </summary>
        public Decimal Freezing_amount
        {
            get { return freezing_amount; }
            set { freezing_amount = value; }
        }

        private Int32 user_id;

        /// <summary>
        /// 
        /// </summary>
        public Int32 User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }
        #endregion

        #region 验证
        public List<string> ErrorList = new List<string>();
        private bool Validator()
        {
            bool validatorResult = true;
            if (this.Create_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Create_time should not be empty!");
            }
            if (this.Update_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Update_time should not be empty!");
            }
            return validatorResult;
        }

        #endregion

        #region 辅助方法
        public Info_account Clone(bool isDeepCopy)
        {
            Info_account footman;
            if (isDeepCopy)
            {
                MemoryStream memoryStream = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                footman = (Info_account)formatter.Deserialize(memoryStream);
            }
            else
            {
                footman = (Info_account)this.MemberwiseClone();
            }
            return footman;
        }
        #endregion

    }


    [Serializable]
    [Table(Name = "account_log")]
    /// <summary>
    ///Info_account_log
    /// </summary>
    public partial class Info_account_log
    {
        #region 构造函数
        public Info_account_log() { }

        public Info_account_log(Int32 id, DateTime create_time, DateTime update_time, Byte can_cashing, Byte bill_type, String pay_no, String pay_way, Int32 user_id, Int32 account_id, Byte is_freezing, Decimal collection_account, Decimal cash)
        {
            this.id = id;
            this.create_time = create_time;
            this.update_time = update_time;
            this.can_cashing = can_cashing;
            this.bill_type = bill_type;
            this.pay_no = pay_no;
            this.pay_way = pay_way;
            this.user_id = user_id;
            this.account_id = account_id;
            this.is_freezing = is_freezing;
            this.collection_account = collection_account;
            this.cash = cash;
        }
        #endregion

        #region 属性

        private Int32 id;

        /// <summary>
        /// 
        /// </summary>
        [Id]
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime? create_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Create_time
        {
            get { return create_time; }
            set { create_time = value; }
        }

        private DateTime? update_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Update_time
        {
            get { return update_time; }
            set { update_time = value; }
        }

        private Byte can_cashing;

        /// <summary>
        /// 
        /// </summary>
        public Byte Can_cashing
        {
            get { return can_cashing; }
            set { can_cashing = value; }
        }

        private Byte bill_type;

        /// <summary>
        /// 
        /// </summary>
        public Byte Bill_type
        {
            get { return bill_type; }
            set { bill_type = value; }
        }

        private String pay_no;

        /// <summary>
        /// 
        /// </summary>
        public String Pay_no
        {
            get { return pay_no; }
            set { pay_no = value; }
        }

        private String pay_way;

        /// <summary>
        /// 
        /// </summary>
        public String Pay_way
        {
            get { return pay_way; }
            set { pay_way = value; }
        }

        private Int32 user_id;

        /// <summary>
        /// 
        /// </summary>
        public Int32 User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }

        private Int32 account_id;

        /// <summary>
        /// 
        /// </summary>
        public Int32 Account_id
        {
            get { return account_id; }
            set { account_id = value; }
        }

        private Byte is_freezing;

        /// <summary>
        /// 
        /// </summary>
        public Byte Is_freezing
        {
            get { return is_freezing; }
            set { is_freezing = value; }
        }

        private Decimal collection_account;

        /// <summary>
        /// 
        /// </summary>
        public Decimal Collection_account
        {
            get { return collection_account; }
            set { collection_account = value; }
        }

        private Decimal cash;

        /// <summary>
        /// 
        /// </summary>
        public Decimal Cash
        {
            get { return cash; }
            set { cash = value; }
        }
        #endregion

        #region 验证
        public List<string> ErrorList = new List<string>();
        private bool Validator()
        {
            bool validatorResult = true;
            if (this.Create_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Create_time should not be empty!");
            }
            if (this.Update_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Update_time should not be empty!");
            }
            if (string.IsNullOrEmpty(this.Pay_no))
            {
                validatorResult = false;
                this.ErrorList.Add("The Pay_no should not be empty!");
            }
            if (this.Pay_no != null && 30 < this.Pay_no.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Pay_no should not be greater then 30!");
            }
            if (string.IsNullOrEmpty(this.Pay_way))
            {
                validatorResult = false;
                this.ErrorList.Add("The Pay_way should not be empty!");
            }
            if (this.Pay_way != null && 50 < this.Pay_way.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Pay_way should not be greater then 50!");
            }
            return validatorResult;
        }

        #endregion

        #region 辅助方法
        public Info_account_log Clone(bool isDeepCopy)
        {
            Info_account_log footman;
            if (isDeepCopy)
            {
                MemoryStream memoryStream = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                footman = (Info_account_log)formatter.Deserialize(memoryStream);
            }
            else
            {
                footman = (Info_account_log)this.MemberwiseClone();
            }
            return footman;
        }
        #endregion

    }


    [Serializable]
    [Table(Name = "user_main")]
    /// <summary>
    ///Info_user_main
    /// </summary>
    public partial class Info_user_main
    {
        #region 构造函数
        public Info_user_main() { }

        public Info_user_main(Int32 id, DateTime create_time, DateTime update_time, Byte is_available, String wx_open_id, String user_name, String password, String passsalt, String wx_name, String wx_code, String wx_picture, String user_picture, String wx_open_id_b, Byte is_locked, String user_nickname)
        {
            this.id = id;
            this.create_time = create_time;
            this.update_time = update_time;
            this.is_available = is_available;
            this.wx_open_id = wx_open_id;
            this.user_name = user_name;
            this.password = password;
            this.passsalt = passsalt;
            this.wx_name = wx_name;
            this.wx_code = wx_code;
            this.wx_picture = wx_picture;
            this.user_picture = user_picture;
            this.wx_open_id_b = wx_open_id_b;
            this.is_locked = is_locked;
            this.user_nickname = user_nickname;
        }
        #endregion

        #region 属性

        private Int32 id;

        /// <summary>
        /// 
        /// </summary>
        [Id]
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime? create_time;

        /// <summary>
        /// weixinweiyibiaozhi
        /// </summary>
        public DateTime? Create_time
        {
            get { return create_time; }
            set { create_time = value; }
        }

        private DateTime? update_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Update_time
        {
            get { return update_time; }
            set { update_time = value; }
        }

        private Byte is_available;

        /// <summary>
        /// 是否可用 可用：0；不可用：1
        /// </summary>
        public Byte Is_available
        {
            get { return is_available; }
            set { is_available = value; }
        }

        private String wx_open_id;

        /// <summary>
        /// 
        /// </summary>
        public String Wx_open_id
        {
            get { return wx_open_id; }
            set { wx_open_id = value; }
        }

        private String user_name;

        /// <summary>
        /// 
        /// </summary>
        public String User_name
        {
            get { return user_name; }
            set { user_name = value; }
        }

        private String password;

        /// <summary>
        /// 
        /// </summary>
        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        private String passsalt;

        /// <summary>
        /// 
        /// </summary>
        public String Passsalt
        {
            get { return passsalt; }
            set { passsalt = value; }
        }

        private String wx_name;

        /// <summary>
        /// 
        /// </summary>
        public String Wx_name
        {
            get { return wx_name; }
            set { wx_name = value; }
        }

        private String wx_code;

        /// <summary>
        /// 
        /// </summary>
        public String Wx_code
        {
            get { return wx_code; }
            set { wx_code = value; }
        }

        private String wx_picture;

        /// <summary>
        /// 
        /// </summary>
        public String Wx_picture
        {
            get { return wx_picture; }
            set { wx_picture = value; }
        }

        private String user_picture;

        /// <summary>
        /// 
        /// </summary>
        public String User_picture
        {
            get { return user_picture; }
            set { user_picture = value; }
        }

        private String wx_open_id_b;

        /// <summary>
        /// 
        /// </summary>
        public String Wx_open_id_b
        {
            get { return wx_open_id_b; }
            set { wx_open_id_b = value; }
        }

        private Byte is_locked;

        /// <summary>
        /// 
        /// </summary>
        public Byte Is_locked
        {
            get { return is_locked; }
            set { is_locked = value; }
        }

        private String user_nickname;

        /// <summary>
        /// 
        /// </summary>
        public String User_nickname
        {
            get { return user_nickname; }
            set { user_nickname = value; }
        }
        #endregion

        #region 验证
        public List<string> ErrorList = new List<string>();
        private bool Validator()
        {
            bool validatorResult = true;
            if (this.Create_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Create_time should not be empty!");
            }
            if (this.Update_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Update_time should not be empty!");
            }
            if (this.Wx_open_id != null && 28 < this.Wx_open_id.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Wx_open_id should not be greater then 28!");
            }
            if (string.IsNullOrEmpty(this.User_name))
            {
                validatorResult = false;
                this.ErrorList.Add("The User_name should not be empty!");
            }
            if (this.User_name != null && 50 < this.User_name.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of User_name should not be greater then 50!");
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                validatorResult = false;
                this.ErrorList.Add("The Password should not be empty!");
            }
            if (this.Password != null && 64 < this.Password.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Password should not be greater then 64!");
            }
            if (string.IsNullOrEmpty(this.Passsalt))
            {
                validatorResult = false;
                this.ErrorList.Add("The Passsalt should not be empty!");
            }
            if (this.Passsalt != null && 36 < this.Passsalt.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Passsalt should not be greater then 36!");
            }
            if (this.Wx_name != null && 30 < this.Wx_name.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Wx_name should not be greater then 30!");
            }
            if (this.Wx_code != null && 20 < this.Wx_code.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Wx_code should not be greater then 20!");
            }
            if (this.Wx_picture != null && 200 < this.Wx_picture.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Wx_picture should not be greater then 200!");
            }
            if (this.User_picture != null && 200 < this.User_picture.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of User_picture should not be greater then 200!");
            }
            if (this.Wx_open_id_b != null && 28 < this.Wx_open_id_b.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Wx_open_id_b should not be greater then 28!");
            }
            if (this.User_nickname != null && 30 < this.User_nickname.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of User_nickname should not be greater then 30!");
            }
            return validatorResult;
        }

        #endregion

        #region 辅助方法
        public Info_user_main Clone(bool isDeepCopy)
        {
            Info_user_main footman;
            if (isDeepCopy)
            {
                MemoryStream memoryStream = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                footman = (Info_user_main)formatter.Deserialize(memoryStream);
            }
            else
            {
                footman = (Info_user_main)this.MemberwiseClone();
            }
            return footman;
        }
        #endregion

    }


    [Serializable]
    [Table(Name = "profit")]
    /// <summary>
    ///Info_profit
    /// </summary>
    public partial class Info_profit
    {
        #region 构造函数
        public Info_profit() { }

        public Info_profit(Int32 id, DateTime create_time, DateTime update_time, Int32 user_id, Int32 account_id, Decimal cash, Byte status, Int32 user_id_c, Decimal payment, String order_no)
        {
            this.id = id;
            this.create_time = create_time;
            this.update_time = update_time;
            this.user_id = user_id;
            this.account_id = account_id;
            this.cash = cash;
            this.status = status;
            this.user_id_c = user_id_c;
            this.payment = payment;
            this.order_no = order_no;
        }
        #endregion

        #region 属性

        private Int32 id;

        /// <summary>
        /// 
        /// </summary>
        [Id]
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime? create_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Create_time
        {
            get { return create_time; }
            set { create_time = value; }
        }

        private DateTime? update_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Update_time
        {
            get { return update_time; }
            set { update_time = value; }
        }

        private Int32 user_id;

        /// <summary>
        /// 
        /// </summary>
        public Int32 User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }

        private Int32 account_id;

        /// <summary>
        /// 
        /// </summary>
        public Int32 Account_id
        {
            get { return account_id; }
            set { account_id = value; }
        }

        private Decimal cash;

        /// <summary>
        /// 
        /// </summary>
        public Decimal Cash
        {
            get { return cash; }
            set { cash = value; }
        }

        private Byte status;

        /// <summary>
        /// 
        /// </summary>
        public Byte Status
        {
            get { return status; }
            set { status = value; }
        }

        private Int32 user_id_c;

        /// <summary>
        /// 
        /// </summary>
        public Int32 User_id_c
        {
            get { return user_id_c; }
            set { user_id_c = value; }
        }

        private Decimal payment;

        /// <summary>
        /// 
        /// </summary>
        public Decimal Payment
        {
            get { return payment; }
            set { payment = value; }
        }

        private String order_no;

        /// <summary>
        /// 
        /// </summary>
        public String Order_no
        {
            get { return order_no; }
            set { order_no = value; }
        }
        #endregion

        #region 验证
        public List<string> ErrorList = new List<string>();
        private bool Validator()
        {
            bool validatorResult = true;
            if (this.Create_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Create_time should not be empty!");
            }
            if (this.Update_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Update_time should not be empty!");
            }
            if (string.IsNullOrEmpty(this.Order_no))
            {
                validatorResult = false;
                this.ErrorList.Add("The Order_no should not be empty!");
            }
            if (this.Order_no != null && 20 < this.Order_no.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Order_no should not be greater then 20!");
            }
            return validatorResult;
        }

        #endregion

        #region 辅助方法
        public Info_profit Clone(bool isDeepCopy)
        {
            Info_profit footman;
            if (isDeepCopy)
            {
                MemoryStream memoryStream = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                footman = (Info_profit)formatter.Deserialize(memoryStream);
            }
            else
            {
                footman = (Info_profit)this.MemberwiseClone();
            }
            return footman;
        }
        #endregion

    }


    [Serializable]
    [Table(Name = "msgtemplatecontent")]
    /// <summary>
    ///Info_msgtemplatecontent
    /// </summary>
    public partial class Info_msgtemplatecontent
    {
        #region 构造函数
        public Info_msgtemplatecontent() { }

        public Info_msgtemplatecontent(String openid, String parameter1, String parameter2, String parameter3, String parameter4, String parameter5, String parameter6, String remark, Byte u_type, DateTime ctime, Int32 isdel, String contentid, Int32 id)
        {
            this.openid = openid;
            this.parameter1 = parameter1;
            this.parameter2 = parameter2;
            this.parameter3 = parameter3;
            this.parameter4 = parameter4;
            this.parameter5 = parameter5;
            this.parameter6 = parameter6;
            this.remark = remark;
            this.u_type = u_type;
            this.ctime = ctime;
            this.isdel = isdel;
            this.contentid = contentid;
            this.id = id;
        }
        #endregion

        #region 属性

        private String openid;

        /// <summary>
        /// 
        /// </summary>
        public String Openid
        {
            get { return openid; }
            set { openid = value; }
        }

        private String parameter1;

        /// <summary>
        /// 
        /// </summary>
        public String Parameter1
        {
            get { return parameter1; }
            set { parameter1 = value; }
        }

        private String parameter2;

        /// <summary>
        /// 
        /// </summary>
        public String Parameter2
        {
            get { return parameter2; }
            set { parameter2 = value; }
        }

        private String parameter3;

        /// <summary>
        /// 
        /// </summary>
        public String Parameter3
        {
            get { return parameter3; }
            set { parameter3 = value; }
        }

        private String parameter4;

        /// <summary>
        /// 
        /// </summary>
        public String Parameter4
        {
            get { return parameter4; }
            set { parameter4 = value; }
        }

        private String parameter5;

        /// <summary>
        /// 
        /// </summary>
        public String Parameter5
        {
            get { return parameter5; }
            set { parameter5 = value; }
        }

        private String parameter6;

        /// <summary>
        /// 
        /// </summary>
        public String Parameter6
        {
            get { return parameter6; }
            set { parameter6 = value; }
        }

        private String remark;

        /// <summary>
        /// 
        /// </summary>
        public String Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        private Byte u_type;

        /// <summary>
        /// 
        /// </summary>
        public Byte U_type
        {
            get { return u_type; }
            set { u_type = value; }
        }

        private DateTime? ctime;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Ctime
        {
            get { return ctime; }
            set { ctime = value; }
        }

        private Int32 isdel;

        /// <summary>
        /// 
        /// </summary>
        public Int32 Isdel
        {
            get { return isdel; }
            set { isdel = value; }
        }

        private String contentid;

        /// <summary>
        /// 
        /// </summary>
        public String Contentid
        {
            get { return contentid; }
            set { contentid = value; }
        }

        private Int32 id;

        /// <summary>
        /// 
        /// </summary>
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }
        #endregion

        #region 验证
        public List<string> ErrorList = new List<string>();
        private bool Validator()
        {
            bool validatorResult = true;
            if (this.Openid != null && 50 < this.Openid.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Openid should not be greater then 50!");
            }
            if (this.Parameter1 != null && 300 < this.Parameter1.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Parameter1 should not be greater then 300!");
            }
            if (this.Parameter2 != null && 300 < this.Parameter2.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Parameter2 should not be greater then 300!");
            }
            if (this.Parameter3 != null && 300 < this.Parameter3.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Parameter3 should not be greater then 300!");
            }
            if (this.Parameter4 != null && 300 < this.Parameter4.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Parameter4 should not be greater then 300!");
            }
            if (this.Parameter5 != null && 300 < this.Parameter5.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Parameter5 should not be greater then 300!");
            }
            if (this.Parameter6 != null && 300 < this.Parameter6.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Parameter6 should not be greater then 300!");
            }
            if (this.Remark != null && 500 < this.Remark.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Remark should not be greater then 500!");
            }
            if (this.Contentid != null && 100 < this.Contentid.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Contentid should not be greater then 100!");
            }
            return validatorResult;
        }

        #endregion

        #region 辅助方法
        public Info_msgtemplatecontent Clone(bool isDeepCopy)
        {
            Info_msgtemplatecontent footman;
            if (isDeepCopy)
            {
                MemoryStream memoryStream = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                footman = (Info_msgtemplatecontent)formatter.Deserialize(memoryStream);
            }
            else
            {
                footman = (Info_msgtemplatecontent)this.MemberwiseClone();
            }
            return footman;
        }
        #endregion

    }


    [Serializable]
    [Table(Name = "dic_message")]
    /// <summary>
    ///Info_dic_message
    /// </summary>
    public partial class Info_dic_message
    {
        #region 构造函数
        public Info_dic_message() { }

        public Info_dic_message(Int32 id, DateTime create_time, DateTime update_time, String code, String code_Parent, String content)
        {
            this.id = id;
            this.create_time = create_time;
            this.update_time = update_time;
            this.code = code;
            this.code_Parent = code_Parent;
            this.content = content;
        }
        #endregion

        #region 属性

        private Int32 id;

        /// <summary>
        /// 
        /// </summary>
        [Id]
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime? create_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Create_time
        {
            get { return create_time; }
            set { create_time = value; }
        }

        private DateTime? update_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Update_time
        {
            get { return update_time; }
            set { update_time = value; }
        }

        private String code;

        /// <summary>
        /// 
        /// </summary>
        public String Code
        {
            get { return code; }
            set { code = value; }
        }

        private String code_Parent;

        /// <summary>
        /// 
        /// </summary>
        public String Code_Parent
        {
            get { return code_Parent; }
            set { code_Parent = value; }
        }

        private String content;

        /// <summary>
        /// 
        /// </summary>
        public String Content
        {
            get { return content; }
            set { content = value; }
        }
        #endregion

        #region 验证
        public List<string> ErrorList = new List<string>();
        private bool Validator()
        {
            bool validatorResult = true;
            if (string.IsNullOrEmpty(this.Code))
            {
                validatorResult = false;
                this.ErrorList.Add("The Code should not be empty!");
            }
            if (this.Code != null && 50 < this.Code.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Code should not be greater then 50!");
            }
            if (this.Code_Parent != null && 50 < this.Code_Parent.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Code_Parent should not be greater then 50!");
            }
            if (string.IsNullOrEmpty(this.Content))
            {
                validatorResult = false;
                this.ErrorList.Add("The Content should not be empty!");
            }
            if (this.Content != null && 100 < this.Content.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Content should not be greater then 100!");
            }
            return validatorResult;
        }

        #endregion

        #region 辅助方法
        public Info_dic_message Clone(bool isDeepCopy)
        {
            Info_dic_message footman;
            if (isDeepCopy)
            {
                MemoryStream memoryStream = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                footman = (Info_dic_message)formatter.Deserialize(memoryStream);
            }
            else
            {
                footman = (Info_dic_message)this.MemberwiseClone();
            }
            return footman;
        }
        #endregion

    }


    [Serializable]
    [Table(Name = "msgtemplatetype")]
    /// <summary>
    ///Info_msgtemplatetype
    /// </summary>
    public partial class Info_msgtemplatetype
    {
        #region 构造函数
        public Info_msgtemplatetype() { }

        public Info_msgtemplatetype(Int32 id, Int32 typeid, Int32 isdel, String desc, String contentid, Byte user_type, DateTime ctime, String templatename, String subtitle, String url)
        {
            this.id = id;
            this.typeid = typeid;
            this.isdel = isdel;
            this.desc = desc;
            this.contentid = contentid;
            this.user_type = user_type;
            this.ctime = ctime;
            this.templatename = templatename;
            this.subtitle = subtitle;
            this.url = url;
        }
        #endregion

        #region 属性

        private Int32 id;

        /// <summary>
        /// 
        /// </summary>
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        private Int32 typeid;

        /// <summary>
        /// 
        /// </summary>
        public Int32 Typeid
        {
            get { return typeid; }
            set { typeid = value; }
        }

        private Int32 isdel;

        /// <summary>
        /// 
        /// </summary>
        public Int32 Isdel
        {
            get { return isdel; }
            set { isdel = value; }
        }

        private String desc;

        /// <summary>
        /// 
        /// </summary>
        public String Desc
        {
            get { return desc; }
            set { desc = value; }
        }

        private String contentid;

        /// <summary>
        /// 
        /// </summary>
        public String Contentid
        {
            get { return contentid; }
            set { contentid = value; }
        }

        private Byte user_type;

        /// <summary>
        /// 
        /// </summary>
        public Byte User_type
        {
            get { return user_type; }
            set { user_type = value; }
        }

        private DateTime? ctime;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Ctime
        {
            get { return ctime; }
            set { ctime = value; }
        }

        private String templatename;

        /// <summary>
        /// 
        /// </summary>
        public String Templatename
        {
            get { return templatename; }
            set { templatename = value; }
        }

        private String subtitle;

        /// <summary>
        /// 
        /// </summary>
        public String Subtitle
        {
            get { return subtitle; }
            set { subtitle = value; }
        }

        private String url;

        /// <summary>
        /// 
        /// </summary>
        public String Url
        {
            get { return url; }
            set { url = value; }
        }
        #endregion

        #region 验证
        public List<string> ErrorList = new List<string>();
        private bool Validator()
        {
            bool validatorResult = true;
            if (this.Desc != null && 300 < this.Desc.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Desc should not be greater then 300!");
            }
            if (this.Contentid != null && 100 < this.Contentid.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Contentid should not be greater then 100!");
            }
            if (this.Templatename != null && 50 < this.Templatename.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Templatename should not be greater then 50!");
            }
            if (this.Subtitle != null && 200 < this.Subtitle.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Subtitle should not be greater then 200!");
            }
            if (this.Url != null && 100 < this.Url.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Url should not be greater then 100!");
            }
            return validatorResult;
        }

        #endregion

        #region 辅助方法
        public Info_msgtemplatetype Clone(bool isDeepCopy)
        {
            Info_msgtemplatetype footman;
            if (isDeepCopy)
            {
                MemoryStream memoryStream = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                footman = (Info_msgtemplatetype)formatter.Deserialize(memoryStream);
            }
            else
            {
                footman = (Info_msgtemplatetype)this.MemberwiseClone();
            }
            return footman;
        }
        #endregion

    }


    [Serializable]
    [Table(Name = "goods_specifications")]
    /// <summary>
    ///Info_goods_specifications
    /// </summary>
    public partial class Info_goods_specifications
    {
        #region 构造函数
        public Info_goods_specifications() { }

        public Info_goods_specifications(Int32 id, DateTime create_time, DateTime update_time, Int32 goods_id, String goods_size, Decimal goods_price, String goods_describe)
        {
            this.id = id;
            this.create_time = create_time;
            this.update_time = update_time;
            this.goods_id = goods_id;
            this.goods_size = goods_size;
            this.goods_price = goods_price;
            this.goods_describe = goods_describe;
        }
        #endregion

        #region 属性

        private Int32 id;

        /// <summary>
        /// 
        /// </summary>
        [Id]
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime? create_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Create_time
        {
            get { return create_time; }
            set { create_time = value; }
        }

        private DateTime? update_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Update_time
        {
            get { return update_time; }
            set { update_time = value; }
        }

        private Int32 goods_id;

        /// <summary>
        /// 
        /// </summary>
        public Int32 Goods_id
        {
            get { return goods_id; }
            set { goods_id = value; }
        }

        private String goods_size;

        /// <summary>
        /// 
        /// </summary>
        public String Goods_size
        {
            get { return goods_size; }
            set { goods_size = value; }
        }

        private Decimal goods_price;

        /// <summary>
        /// 
        /// </summary>
        public Decimal Goods_price
        {
            get { return goods_price; }
            set { goods_price = value; }
        }

        private String goods_describe;

        /// <summary>
        /// 
        /// </summary>
        public String Goods_describe
        {
            get { return goods_describe; }
            set { goods_describe = value; }
        }
        #endregion

        #region 验证
        public List<string> ErrorList = new List<string>();
        private bool Validator()
        {
            bool validatorResult = true;
            if (this.Create_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Create_time should not be empty!");
            }
            if (this.Update_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Update_time should not be empty!");
            }
            if (string.IsNullOrEmpty(this.Goods_size))
            {
                validatorResult = false;
                this.ErrorList.Add("The Goods_size should not be empty!");
            }
            if (this.Goods_size != null && 30 < this.Goods_size.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Goods_size should not be greater then 30!");
            }
            if (this.Goods_describe != null && 200 < this.Goods_describe.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Goods_describe should not be greater then 200!");
            }
            return validatorResult;
        }

        #endregion

        #region 辅助方法
        public Info_goods_specifications Clone(bool isDeepCopy)
        {
            Info_goods_specifications footman;
            if (isDeepCopy)
            {
                MemoryStream memoryStream = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                footman = (Info_goods_specifications)formatter.Deserialize(memoryStream);
            }
            else
            {
                footman = (Info_goods_specifications)this.MemberwiseClone();
            }
            return footman;
        }
        #endregion

    }


    [Serializable]
    [Table(Name = "user_type")]
    /// <summary>
    ///Info_user_type
    /// </summary>
    public partial class Info_user_type
    {
        #region 构造函数
        public Info_user_type() { }

        public Info_user_type(Int32 id, Int32 user_id, Byte user_type, String user_type_name, DateTime create_time, DateTime update_time, String company)
        {
            this.id = id;
            this.user_id = user_id;
            this.user_type = user_type;
            this.user_type_name = user_type_name;
            this.create_time = create_time;
            this.update_time = update_time;
            this.company = company;
        }
        #endregion

        #region 属性

        private Int32 id;

        /// <summary>
        /// 
        /// </summary>
        [Id]
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        private Int32 user_id;

        /// <summary>
        /// yonghuzhubiaowaijian
        /// </summary>
        public Int32 User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }

        private Byte user_type;

        /// <summary>
        /// 用户类型：B类型：0；C类型：1；
        /// </summary>
        public Byte User_type
        {
            get { return user_type; }
            set { user_type = value; }
        }

        private String user_type_name;

        /// <summary>
        /// 
        /// </summary>
        public String User_type_name
        {
            get { return user_type_name; }
            set { user_type_name = value; }
        }

        private DateTime? create_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Create_time
        {
            get { return create_time; }
            set { create_time = value; }
        }

        private DateTime? update_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Update_time
        {
            get { return update_time; }
            set { update_time = value; }
        }

        private String company;

        /// <summary>
        /// 
        /// </summary>
        public String Company
        {
            get { return company; }
            set { company = value; }
        }
        #endregion

        #region 验证
        public List<string> ErrorList = new List<string>();
        private bool Validator()
        {
            bool validatorResult = true;
            if (string.IsNullOrEmpty(this.User_type_name))
            {
                validatorResult = false;
                this.ErrorList.Add("The User_type_name should not be empty!");
            }
            if (this.User_type_name != null && 20 < this.User_type_name.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of User_type_name should not be greater then 20!");
            }
            if (this.Create_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Create_time should not be empty!");
            }
            if (this.Update_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Update_time should not be empty!");
            }
            if (this.Company != null && 50 < this.Company.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Company should not be greater then 50!");
            }
            return validatorResult;
        }

        #endregion

        #region 辅助方法
        public Info_user_type Clone(bool isDeepCopy)
        {
            Info_user_type footman;
            if (isDeepCopy)
            {
                MemoryStream memoryStream = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                footman = (Info_user_type)formatter.Deserialize(memoryStream);
            }
            else
            {
                footman = (Info_user_type)this.MemberwiseClone();
            }
            return footman;
        }
        #endregion

    }


    [Serializable]
    [Table(Name = "order_main")]
    /// <summary>
    ///Info_order_main
    /// </summary>
    public partial class Info_order_main
    {
        #region 构造函数
        public Info_order_main() { }

        public Info_order_main(Int32 id, DateTime create_time, DateTime update_time, String order_no, String order_status, Decimal price_total, Decimal goods_discount, Decimal freight, Decimal freight_discount)
        {
            this.id = id;
            this.create_time = create_time;
            this.update_time = update_time;
            this.order_no = order_no;
            this.order_status = order_status;
            this.price_total = price_total;
            this.goods_discount = goods_discount;
            this.freight = freight;
            this.freight_discount = freight_discount;
        }
        #endregion

        #region 属性

        private Int32 id;

        /// <summary>
        /// 
        /// </summary>
        [Id]
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime? create_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Create_time
        {
            get { return create_time; }
            set { create_time = value; }
        }

        private DateTime? update_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Update_time
        {
            get { return update_time; }
            set { update_time = value; }
        }

        private String order_no;

        /// <summary>
        /// 
        /// </summary>
        public String Order_no
        {
            get { return order_no; }
            set { order_no = value; }
        }

        private String order_status;

        /// <summary>
        /// 
        /// </summary>
        public String Order_status
        {
            get { return order_status; }
            set { order_status = value; }
        }

        private Decimal price_total;

        /// <summary>
        /// 
        /// </summary>
        public Decimal Price_total
        {
            get { return price_total; }
            set { price_total = value; }
        }

        private Decimal goods_discount;

        /// <summary>
        /// 
        /// </summary>
        public Decimal Goods_discount
        {
            get { return goods_discount; }
            set { goods_discount = value; }
        }

        private Decimal freight;

        /// <summary>
        /// 
        /// </summary>
        public Decimal Freight
        {
            get { return freight; }
            set { freight = value; }
        }

        private Decimal freight_discount;

        /// <summary>
        /// 
        /// </summary>
        public Decimal Freight_discount
        {
            get { return freight_discount; }
            set { freight_discount = value; }
        }
        #endregion

        #region 验证
        public List<string> ErrorList = new List<string>();
        private bool Validator()
        {
            bool validatorResult = true;
            if (this.Create_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Create_time should not be empty!");
            }
            if (this.Update_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Update_time should not be empty!");
            }
            if (string.IsNullOrEmpty(this.Order_no))
            {
                validatorResult = false;
                this.ErrorList.Add("The Order_no should not be empty!");
            }
            if (this.Order_no != null && 20 < this.Order_no.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Order_no should not be greater then 20!");
            }
            if (string.IsNullOrEmpty(this.Order_status))
            {
                validatorResult = false;
                this.ErrorList.Add("The Order_status should not be empty!");
            }
            if (this.Order_status != null && 8 < this.Order_status.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Order_status should not be greater then 8!");
            }
            return validatorResult;
        }

        #endregion

        #region 辅助方法
        public Info_order_main Clone(bool isDeepCopy)
        {
            Info_order_main footman;
            if (isDeepCopy)
            {
                MemoryStream memoryStream = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                footman = (Info_order_main)formatter.Deserialize(memoryStream);
            }
            else
            {
                footman = (Info_order_main)this.MemberwiseClone();
            }
            return footman;
        }
        #endregion

    }


    [Serializable]
    [Table(Name = "order_pay_info")]
    /// <summary>
    ///Info_order_pay_info
    /// </summary>
    public partial class Info_order_pay_info
    {
        #region 构造函数
        public Info_order_pay_info() { }

        public Info_order_pay_info(Int32 id, DateTime create_time, DateTime update_time, String pay_no, String pay_way, Decimal pay_money, String order_no)
        {
            this.id = id;
            this.create_time = create_time;
            this.update_time = update_time;
            this.pay_no = pay_no;
            this.pay_way = pay_way;
            this.pay_money = pay_money;
            this.order_no = order_no;
        }
        #endregion

        #region 属性

        private Int32 id;

        /// <summary>
        /// 
        /// </summary>
        [Id]
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime? create_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Create_time
        {
            get { return create_time; }
            set { create_time = value; }
        }

        private DateTime? update_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Update_time
        {
            get { return update_time; }
            set { update_time = value; }
        }

        private String pay_no;

        /// <summary>
        /// 
        /// </summary>
        public String Pay_no
        {
            get { return pay_no; }
            set { pay_no = value; }
        }

        private String pay_way;

        /// <summary>
        /// 
        /// </summary>
        public String Pay_way
        {
            get { return pay_way; }
            set { pay_way = value; }
        }

        private Decimal pay_money;

        /// <summary>
        /// 
        /// </summary>
        public Decimal Pay_money
        {
            get { return pay_money; }
            set { pay_money = value; }
        }

        private String order_no;

        /// <summary>
        /// 
        /// </summary>
        public String Order_no
        {
            get { return order_no; }
            set { order_no = value; }
        }
        #endregion

        #region 验证
        public List<string> ErrorList = new List<string>();
        private bool Validator()
        {
            bool validatorResult = true;
            if (this.Create_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Create_time should not be empty!");
            }
            if (this.Update_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Update_time should not be empty!");
            }
            if (string.IsNullOrEmpty(this.Pay_no))
            {
                validatorResult = false;
                this.ErrorList.Add("The Pay_no should not be empty!");
            }
            if (this.Pay_no != null && 30 < this.Pay_no.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Pay_no should not be greater then 30!");
            }
            if (string.IsNullOrEmpty(this.Pay_way))
            {
                validatorResult = false;
                this.ErrorList.Add("The Pay_way should not be empty!");
            }
            if (this.Pay_way != null && 10 < this.Pay_way.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Pay_way should not be greater then 10!");
            }
            if (string.IsNullOrEmpty(this.Order_no))
            {
                validatorResult = false;
                this.ErrorList.Add("The Order_no should not be empty!");
            }
            if (this.Order_no != null && 20 < this.Order_no.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Order_no should not be greater then 20!");
            }
            return validatorResult;
        }

        #endregion

        #region 辅助方法
        public Info_order_pay_info Clone(bool isDeepCopy)
        {
            Info_order_pay_info footman;
            if (isDeepCopy)
            {
                MemoryStream memoryStream = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                footman = (Info_order_pay_info)formatter.Deserialize(memoryStream);
            }
            else
            {
                footman = (Info_order_pay_info)this.MemberwiseClone();
            }
            return footman;
        }
        #endregion

    }


    [Serializable]
    [Table(Name = "user_b2c")]
    /// <summary>
    ///Info_user_b2c
    /// </summary>
    public partial class Info_user_b2c
    {
        #region 构造函数
        public Info_user_b2c() { }

        public Info_user_b2c(Int32 id, Int32 user_id_b, Int32 user_id_c, String wx_picture, String wx_code, String wx_name, DateTime create_time, DateTime update_time)
        {
            this.id = id;
            this.user_id_b = user_id_b;
            this.user_id_c = user_id_c;
            this.wx_picture = wx_picture;
            this.wx_code = wx_code;
            this.wx_name = wx_name;
            this.create_time = create_time;
            this.update_time = update_time;
        }
        #endregion

        #region 属性

        private Int32 id;

        /// <summary>
        /// 
        /// </summary>
        [Id]
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        private Int32 user_id_b;

        /// <summary>
        /// 
        /// </summary>
        public Int32 User_id_b
        {
            get { return user_id_b; }
            set { user_id_b = value; }
        }

        private Int32 user_id_c;

        /// <summary>
        /// 
        /// </summary>
        public Int32 User_id_c
        {
            get { return user_id_c; }
            set { user_id_c = value; }
        }

        private String wx_picture;

        /// <summary>
        /// 
        /// </summary>
        public String Wx_picture
        {
            get { return wx_picture; }
            set { wx_picture = value; }
        }

        private String wx_code;

        /// <summary>
        /// 
        /// </summary>
        public String Wx_code
        {
            get { return wx_code; }
            set { wx_code = value; }
        }

        private String wx_name;

        /// <summary>
        /// 
        /// </summary>
        public String Wx_name
        {
            get { return wx_name; }
            set { wx_name = value; }
        }

        private DateTime? create_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Create_time
        {
            get { return create_time; }
            set { create_time = value; }
        }

        private DateTime? update_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Update_time
        {
            get { return update_time; }
            set { update_time = value; }
        }
        #endregion

        #region 验证
        public List<string> ErrorList = new List<string>();
        private bool Validator()
        {
            bool validatorResult = true;
            if (this.Wx_picture != null && 200 < this.Wx_picture.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Wx_picture should not be greater then 200!");
            }
            if (this.Wx_code != null && 20 < this.Wx_code.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Wx_code should not be greater then 20!");
            }
            if (this.Wx_name != null && 30 < this.Wx_name.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Wx_name should not be greater then 30!");
            }
            if (this.Create_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Create_time should not be empty!");
            }
            if (this.Update_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Update_time should not be empty!");
            }
            return validatorResult;
        }

        #endregion

        #region 辅助方法
        public Info_user_b2c Clone(bool isDeepCopy)
        {
            Info_user_b2c footman;
            if (isDeepCopy)
            {
                MemoryStream memoryStream = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                footman = (Info_user_b2c)formatter.Deserialize(memoryStream);
            }
            else
            {
                footman = (Info_user_b2c)this.MemberwiseClone();
            }
            return footman;
        }
        #endregion

    }


    [Serializable]
    [Table(Name = "user_pickup_info")]
    /// <summary>
    ///Info_user_pickup_info
    /// </summary>
    public partial class Info_user_pickup_info
    {
        #region 构造函数
        public Info_user_pickup_info() { }

        public Info_user_pickup_info(Int32 id, Int32 user_id, DateTime create_time, DateTime update_time, Byte is_default, String mobilephone, String name, String address, String country, String province, String city, String county, String village)
        {
            this.id = id;
            this.user_id = user_id;
            this.create_time = create_time;
            this.update_time = update_time;
            this.is_default = is_default;
            this.mobilephone = mobilephone;
            this.name = name;
            this.address = address;
            this.country = country;
            this.province = province;
            this.city = city;
            this.county = county;
            this.village = village;
        }
        #endregion

        #region 属性

        private Int32 id;

        /// <summary>
        /// 
        /// </summary>
        [Id]
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        private Int32 user_id;

        /// <summary>
        /// 
        /// </summary>
        public Int32 User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }

        private DateTime? create_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Create_time
        {
            get { return create_time; }
            set { create_time = value; }
        }

        private DateTime? update_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Update_time
        {
            get { return update_time; }
            set { update_time = value; }
        }

        private Byte is_default;

        /// <summary>
        /// 
        /// </summary>
        public Byte Is_default
        {
            get { return is_default; }
            set { is_default = value; }
        }

        private String mobilephone;

        /// <summary>
        /// 
        /// </summary>
        public String Mobilephone
        {
            get { return mobilephone; }
            set { mobilephone = value; }
        }

        private String name;

        /// <summary>
        /// 
        /// </summary>
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private String address;

        /// <summary>
        /// 
        /// </summary>
        public String Address
        {
            get { return address; }
            set { address = value; }
        }

        private String country;

        /// <summary>
        /// 
        /// </summary>
        public String Country
        {
            get { return country; }
            set { country = value; }
        }

        private String province;

        /// <summary>
        /// 
        /// </summary>
        public String Province
        {
            get { return province; }
            set { province = value; }
        }

        private String city;

        /// <summary>
        /// 
        /// </summary>
        public String City
        {
            get { return city; }
            set { city = value; }
        }

        private String county;

        /// <summary>
        /// 
        /// </summary>
        public String County
        {
            get { return county; }
            set { county = value; }
        }

        private String village;

        /// <summary>
        /// 
        /// </summary>
        public String Village
        {
            get { return village; }
            set { village = value; }
        }
        #endregion

        #region 验证
        public List<string> ErrorList = new List<string>();
        private bool Validator()
        {
            bool validatorResult = true;
            if (this.Create_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Create_time should not be empty!");
            }
            if (this.Update_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Update_time should not be empty!");
            }
            if (string.IsNullOrEmpty(this.Mobilephone))
            {
                validatorResult = false;
                this.ErrorList.Add("The Mobilephone should not be empty!");
            }
            if (this.Mobilephone != null && 11 < this.Mobilephone.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Mobilephone should not be greater then 11!");
            }
            if (string.IsNullOrEmpty(this.Name))
            {
                validatorResult = false;
                this.ErrorList.Add("The Name should not be empty!");
            }
            if (this.Name != null && 20 < this.Name.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Name should not be greater then 20!");
            }
            if (string.IsNullOrEmpty(this.Address))
            {
                validatorResult = false;
                this.ErrorList.Add("The Address should not be empty!");
            }
            if (this.Address != null && 200 < this.Address.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Address should not be greater then 200!");
            }
            if (string.IsNullOrEmpty(this.Country))
            {
                validatorResult = false;
                this.ErrorList.Add("The Country should not be empty!");
            }
            if (this.Country != null && 30 < this.Country.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Country should not be greater then 30!");
            }
            if (string.IsNullOrEmpty(this.Province))
            {
                validatorResult = false;
                this.ErrorList.Add("The Province should not be empty!");
            }
            if (this.Province != null && 30 < this.Province.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Province should not be greater then 30!");
            }
            if (string.IsNullOrEmpty(this.City))
            {
                validatorResult = false;
                this.ErrorList.Add("The City should not be empty!");
            }
            if (this.City != null && 30 < this.City.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of City should not be greater then 30!");
            }
            if (string.IsNullOrEmpty(this.County))
            {
                validatorResult = false;
                this.ErrorList.Add("The County should not be empty!");
            }
            if (this.County != null && 30 < this.County.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of County should not be greater then 30!");
            }
            if (string.IsNullOrEmpty(this.Village))
            {
                validatorResult = false;
                this.ErrorList.Add("The Village should not be empty!");
            }
            if (this.Village != null && 140 < this.Village.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Village should not be greater then 140!");
            }
            return validatorResult;
        }

        #endregion

        #region 辅助方法
        public Info_user_pickup_info Clone(bool isDeepCopy)
        {
            Info_user_pickup_info footman;
            if (isDeepCopy)
            {
                MemoryStream memoryStream = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                footman = (Info_user_pickup_info)formatter.Deserialize(memoryStream);
            }
            else
            {
                footman = (Info_user_pickup_info)this.MemberwiseClone();
            }
            return footman;
        }
        #endregion

    }


    [Serializable]
    [Table(Name = "user_picture")]
    /// <summary>
    ///Info_user_picture
    /// </summary>
    public partial class Info_user_picture
    {
        #region 构造函数
        public Info_user_picture() { }

        public Info_user_picture(Int32 id, DateTime create_time, DateTime update_time, String picture_url, String picture_file_name, String picture_describe, Byte picture_type, Int32 user_id)
        {
            this.id = id;
            this.create_time = create_time;
            this.update_time = update_time;
            this.picture_url = picture_url;
            this.picture_file_name = picture_file_name;
            this.picture_describe = picture_describe;
            this.picture_type = picture_type;
            this.user_id = user_id;
        }
        #endregion

        #region 属性

        private Int32 id;

        /// <summary>
        /// 
        /// </summary>
        [Id]
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime? create_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Create_time
        {
            get { return create_time; }
            set { create_time = value; }
        }

        private DateTime? update_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Update_time
        {
            get { return update_time; }
            set { update_time = value; }
        }

        private String picture_url;

        /// <summary>
        /// 
        /// </summary>
        public String Picture_url
        {
            get { return picture_url; }
            set { picture_url = value; }
        }

        private String picture_file_name;

        /// <summary>
        /// 
        /// </summary>
        public String Picture_file_name
        {
            get { return picture_file_name; }
            set { picture_file_name = value; }
        }

        private String picture_describe;

        /// <summary>
        /// 
        /// </summary>
        public String Picture_describe
        {
            get { return picture_describe; }
            set { picture_describe = value; }
        }

        private Byte picture_type;

        /// <summary>
        /// 
        /// </summary>
        public Byte Picture_type
        {
            get { return picture_type; }
            set { picture_type = value; }
        }

        private Int32 user_id;

        /// <summary>
        /// 
        /// </summary>
        public Int32 User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }
        #endregion

        #region 验证
        public List<string> ErrorList = new List<string>();
        private bool Validator()
        {
            bool validatorResult = true;
            if (this.Create_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Create_time should not be empty!");
            }
            if (this.Update_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Update_time should not be empty!");
            }
            if (string.IsNullOrEmpty(this.Picture_url))
            {
                validatorResult = false;
                this.ErrorList.Add("The Picture_url should not be empty!");
            }
            if (this.Picture_url != null && 200 < this.Picture_url.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Picture_url should not be greater then 200!");
            }
            if (string.IsNullOrEmpty(this.Picture_file_name))
            {
                validatorResult = false;
                this.ErrorList.Add("The Picture_file_name should not be empty!");
            }
            if (this.Picture_file_name != null && 32 < this.Picture_file_name.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Picture_file_name should not be greater then 32!");
            }
            if (this.Picture_describe != null && 32 < this.Picture_describe.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Picture_describe should not be greater then 32!");
            }
            return validatorResult;
        }

        #endregion

        #region 辅助方法
        public Info_user_picture Clone(bool isDeepCopy)
        {
            Info_user_picture footman;
            if (isDeepCopy)
            {
                MemoryStream memoryStream = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                footman = (Info_user_picture)formatter.Deserialize(memoryStream);
            }
            else
            {
                footman = (Info_user_picture)this.MemberwiseClone();
            }
            return footman;
        }
        #endregion

    }


    [Serializable]
    [Table(Name = "user_shop")]
    /// <summary>
    ///Info_user_shop
    /// </summary>
    public partial class Info_user_shop
    {
        #region 构造函数
        public Info_user_shop() { }

        public Info_user_shop(Int32 id, DateTime create_time, DateTime update_time, Int32 user_id, String shop_name, String shop_address, String shop_describe)
        {
            this.id = id;
            this.create_time = create_time;
            this.update_time = update_time;
            this.user_id = user_id;
            this.shop_name = shop_name;
            this.shop_address = shop_address;
            this.shop_describe = shop_describe;
        }
        #endregion

        #region 属性

        private Int32 id;

        /// <summary>
        /// 
        /// </summary>
        [Id]
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime? create_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Create_time
        {
            get { return create_time; }
            set { create_time = value; }
        }

        private DateTime? update_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Update_time
        {
            get { return update_time; }
            set { update_time = value; }
        }

        private Int32 user_id;

        /// <summary>
        /// 
        /// </summary>
        public Int32 User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }

        private String shop_name;

        /// <summary>
        /// 
        /// </summary>
        public String Shop_name
        {
            get { return shop_name; }
            set { shop_name = value; }
        }

        private String shop_address;

        /// <summary>
        /// 
        /// </summary>
        public String Shop_address
        {
            get { return shop_address; }
            set { shop_address = value; }
        }

        private String shop_describe;

        /// <summary>
        /// 
        /// </summary>
        public String Shop_describe
        {
            get { return shop_describe; }
            set { shop_describe = value; }
        }
        #endregion

        #region 验证
        public List<string> ErrorList = new List<string>();
        private bool Validator()
        {
            bool validatorResult = true;
            if (this.Create_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Create_time should not be empty!");
            }
            if (this.Update_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Update_time should not be empty!");
            }
            if (this.Shop_name != null && 30 < this.Shop_name.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Shop_name should not be greater then 30!");
            }
            if (this.Shop_address != null && 32 < this.Shop_address.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Shop_address should not be greater then 32!");
            }
            if (this.Shop_describe != null && 200 < this.Shop_describe.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Shop_describe should not be greater then 200!");
            }
            return validatorResult;
        }

        #endregion

        #region 辅助方法
        public Info_user_shop Clone(bool isDeepCopy)
        {
            Info_user_shop footman;
            if (isDeepCopy)
            {
                MemoryStream memoryStream = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                footman = (Info_user_shop)formatter.Deserialize(memoryStream);
            }
            else
            {
                footman = (Info_user_shop)this.MemberwiseClone();
            }
            return footman;
        }
        #endregion

    }


    [Serializable]
    [Table(Name = "order_pickup_info")]
    /// <summary>
    ///Info_order_pickup_info
    /// </summary>
    public partial class Info_order_pickup_info
    {
        #region 构造函数
        public Info_order_pickup_info() { }

        public Info_order_pickup_info(Int32 id, DateTime create_time, DateTime update_time, String name, String mobilephone, String address, String order_no)
        {
            this.id = id;
            this.create_time = create_time;
            this.update_time = update_time;
            this.name = name;
            this.mobilephone = mobilephone;
            this.address = address;
            this.order_no = order_no;
        }
        #endregion

        #region 属性

        private Int32 id;

        /// <summary>
        /// 
        /// </summary>
        [Id]
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime? create_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Create_time
        {
            get { return create_time; }
            set { create_time = value; }
        }

        private DateTime? update_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Update_time
        {
            get { return update_time; }
            set { update_time = value; }
        }

        private String name;

        /// <summary>
        /// 
        /// </summary>
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private String mobilephone;

        /// <summary>
        /// 
        /// </summary>
        public String Mobilephone
        {
            get { return mobilephone; }
            set { mobilephone = value; }
        }

        private String address;

        /// <summary>
        /// 
        /// </summary>
        public String Address
        {
            get { return address; }
            set { address = value; }
        }

        private String order_no;

        /// <summary>
        /// 
        /// </summary>
        public String Order_no
        {
            get { return order_no; }
            set { order_no = value; }
        }
        #endregion

        #region 验证
        public List<string> ErrorList = new List<string>();
        private bool Validator()
        {
            bool validatorResult = true;
            if (this.Create_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Create_time should not be empty!");
            }
            if (this.Update_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Update_time should not be empty!");
            }
            if (string.IsNullOrEmpty(this.Name))
            {
                validatorResult = false;
                this.ErrorList.Add("The Name should not be empty!");
            }
            if (this.Name != null && 20 < this.Name.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Name should not be greater then 20!");
            }
            if (string.IsNullOrEmpty(this.Mobilephone))
            {
                validatorResult = false;
                this.ErrorList.Add("The Mobilephone should not be empty!");
            }
            if (this.Mobilephone != null && 11 < this.Mobilephone.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Mobilephone should not be greater then 11!");
            }
            if (string.IsNullOrEmpty(this.Address))
            {
                validatorResult = false;
                this.ErrorList.Add("The Address should not be empty!");
            }
            if (this.Address != null && 200 < this.Address.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Address should not be greater then 200!");
            }
            if (string.IsNullOrEmpty(this.Order_no))
            {
                validatorResult = false;
                this.ErrorList.Add("The Order_no should not be empty!");
            }
            if (this.Order_no != null && 20 < this.Order_no.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Order_no should not be greater then 20!");
            }
            return validatorResult;
        }

        #endregion

        #region 辅助方法
        public Info_order_pickup_info Clone(bool isDeepCopy)
        {
            Info_order_pickup_info footman;
            if (isDeepCopy)
            {
                MemoryStream memoryStream = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                footman = (Info_order_pickup_info)formatter.Deserialize(memoryStream);
            }
            else
            {
                footman = (Info_order_pickup_info)this.MemberwiseClone();
            }
            return footman;
        }
        #endregion

    }


    [Serializable]
    [Table(Name = "order_goods")]
    /// <summary>
    ///Info_order_goods
    /// </summary>
    public partial class Info_order_goods
    {
        #region 构造函数
        public Info_order_goods() { }

        public Info_order_goods(Int32 id, DateTime create_time, DateTime update_time, String goods_name, String goods_size, Int32 goods_count, Decimal goods_price, Decimal goods_discount, Int32 order_id, String order_no)
        {
            this.id = id;
            this.create_time = create_time;
            this.update_time = update_time;
            this.goods_name = goods_name;
            this.goods_size = goods_size;
            this.goods_count = goods_count;
            this.goods_price = goods_price;
            this.goods_discount = goods_discount;
            this.order_id = order_id;
            this.order_no = order_no;
        }
        #endregion

        #region 属性

        private Int32 id;

        /// <summary>
        /// 
        /// </summary>
        [Id]
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime? create_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Create_time
        {
            get { return create_time; }
            set { create_time = value; }
        }

        private DateTime? update_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Update_time
        {
            get { return update_time; }
            set { update_time = value; }
        }

        private String goods_name;

        /// <summary>
        /// 
        /// </summary>
        public String Goods_name
        {
            get { return goods_name; }
            set { goods_name = value; }
        }

        private String goods_size;

        /// <summary>
        /// 
        /// </summary>
        public String Goods_size
        {
            get { return goods_size; }
            set { goods_size = value; }
        }

        private Int32 goods_count;

        /// <summary>
        /// 
        /// </summary>
        public Int32 Goods_count
        {
            get { return goods_count; }
            set { goods_count = value; }
        }

        private Decimal goods_price;

        /// <summary>
        /// 
        /// </summary>
        public Decimal Goods_price
        {
            get { return goods_price; }
            set { goods_price = value; }
        }

        private Decimal goods_discount;

        /// <summary>
        /// 
        /// </summary>
        public Decimal Goods_discount
        {
            get { return goods_discount; }
            set { goods_discount = value; }
        }

        private Int32 order_id;

        /// <summary>
        /// 
        /// </summary>
        public Int32 Order_id
        {
            get { return order_id; }
            set { order_id = value; }
        }

        private String order_no;

        /// <summary>
        /// 
        /// </summary>
        public String Order_no
        {
            get { return order_no; }
            set { order_no = value; }
        }
        #endregion

        #region 验证
        public List<string> ErrorList = new List<string>();
        private bool Validator()
        {
            bool validatorResult = true;
            if (this.Create_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Create_time should not be empty!");
            }
            if (this.Update_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Update_time should not be empty!");
            }
            if (string.IsNullOrEmpty(this.Goods_name))
            {
                validatorResult = false;
                this.ErrorList.Add("The Goods_name should not be empty!");
            }
            if (this.Goods_name != null && 120 < this.Goods_name.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Goods_name should not be greater then 120!");
            }
            if (string.IsNullOrEmpty(this.Goods_size))
            {
                validatorResult = false;
                this.ErrorList.Add("The Goods_size should not be empty!");
            }
            if (this.Goods_size != null && 20 < this.Goods_size.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Goods_size should not be greater then 20!");
            }
            if (string.IsNullOrEmpty(this.Order_no))
            {
                validatorResult = false;
                this.ErrorList.Add("The Order_no should not be empty!");
            }
            if (this.Order_no != null && 20 < this.Order_no.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Order_no should not be greater then 20!");
            }
            return validatorResult;
        }

        #endregion

        #region 辅助方法
        public Info_order_goods Clone(bool isDeepCopy)
        {
            Info_order_goods footman;
            if (isDeepCopy)
            {
                MemoryStream memoryStream = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                footman = (Info_order_goods)formatter.Deserialize(memoryStream);
            }
            else
            {
                footman = (Info_order_goods)this.MemberwiseClone();
            }
            return footman;
        }
        #endregion

    }


    [Serializable]
    [Table(Name = "order_log")]
    /// <summary>
    ///Info_order_log
    /// </summary>
    public partial class Info_order_log
    {
        #region 构造函数
        public Info_order_log() { }

        public Info_order_log(Int32 id, DateTime create_time, DateTime update_time, Int32 order_id, String order_no, String order_status)
        {
            this.id = id;
            this.create_time = create_time;
            this.update_time = update_time;
            this.order_id = order_id;
            this.order_no = order_no;
            this.order_status = order_status;
        }
        #endregion

        #region 属性

        private Int32 id;

        /// <summary>
        /// 
        /// </summary>
        [Id]
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime? create_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Create_time
        {
            get { return create_time; }
            set { create_time = value; }
        }

        private DateTime? update_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Update_time
        {
            get { return update_time; }
            set { update_time = value; }
        }

        private Int32 order_id;

        /// <summary>
        /// 
        /// </summary>
        public Int32 Order_id
        {
            get { return order_id; }
            set { order_id = value; }
        }

        private String order_no;

        /// <summary>
        /// 
        /// </summary>
        public String Order_no
        {
            get { return order_no; }
            set { order_no = value; }
        }

        private String order_status;

        /// <summary>
        /// 
        /// </summary>
        public String Order_status
        {
            get { return order_status; }
            set { order_status = value; }
        }
        #endregion

        #region 验证
        public List<string> ErrorList = new List<string>();
        private bool Validator()
        {
            bool validatorResult = true;
            if (this.Order_no != null && 20 < this.Order_no.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Order_no should not be greater then 20!");
            }
            if (this.Order_status != null && 8 < this.Order_status.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Order_status should not be greater then 8!");
            }
            return validatorResult;
        }

        #endregion

        #region 辅助方法
        public Info_order_log Clone(bool isDeepCopy)
        {
            Info_order_log footman;
            if (isDeepCopy)
            {
                MemoryStream memoryStream = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                footman = (Info_order_log)formatter.Deserialize(memoryStream);
            }
            else
            {
                footman = (Info_order_log)this.MemberwiseClone();
            }
            return footman;
        }
        #endregion

    }


    [Serializable]
    [Table(Name = "goods")]
    /// <summary>
    ///Info_goods
    /// </summary>
    public partial class Info_goods
    {
        #region 构造函数
        public Info_goods() { }

        public Info_goods(Int32 id, DateTime create_time, DateTime update_time, String goods_name, String goods_describe, Int32 goods_sort_id)
        {
            this.id = id;
            this.create_time = create_time;
            this.update_time = update_time;
            this.goods_name = goods_name;
            this.goods_describe = goods_describe;
            this.goods_sort_id = goods_sort_id;
        }
        #endregion

        #region 属性

        private Int32 id;

        /// <summary>
        /// 
        /// </summary>
        [Id]
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime? create_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Create_time
        {
            get { return create_time; }
            set { create_time = value; }
        }

        private DateTime? update_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Update_time
        {
            get { return update_time; }
            set { update_time = value; }
        }

        private String goods_name;

        /// <summary>
        /// 
        /// </summary>
        public String Goods_name
        {
            get { return goods_name; }
            set { goods_name = value; }
        }

        private String goods_describe;

        /// <summary>
        /// 
        /// </summary>
        public String Goods_describe
        {
            get { return goods_describe; }
            set { goods_describe = value; }
        }

        private Int32 goods_sort_id;

        /// <summary>
        /// 
        /// </summary>
        public Int32 Goods_sort_id
        {
            get { return goods_sort_id; }
            set { goods_sort_id = value; }
        }
        #endregion

        #region 验证
        public List<string> ErrorList = new List<string>();
        private bool Validator()
        {
            bool validatorResult = true;
            if (this.Create_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Create_time should not be empty!");
            }
            if (this.Update_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Update_time should not be empty!");
            }
            if (string.IsNullOrEmpty(this.Goods_name))
            {
                validatorResult = false;
                this.ErrorList.Add("The Goods_name should not be empty!");
            }
            if (this.Goods_name != null && 50 < this.Goods_name.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Goods_name should not be greater then 50!");
            }
            if (this.Goods_describe != null && 200 < this.Goods_describe.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Goods_describe should not be greater then 200!");
            }
            return validatorResult;
        }

        #endregion

        #region 辅助方法
        public Info_goods Clone(bool isDeepCopy)
        {
            Info_goods footman;
            if (isDeepCopy)
            {
                MemoryStream memoryStream = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                footman = (Info_goods)formatter.Deserialize(memoryStream);
            }
            else
            {
                footman = (Info_goods)this.MemberwiseClone();
            }
            return footman;
        }
        #endregion

    }


    [Serializable]
    [Table(Name = "goods_sort")]
    /// <summary>
    ///Info_goods_sort
    /// </summary>
    public partial class Info_goods_sort
    {
        #region 构造函数
        public Info_goods_sort() { }

        public Info_goods_sort(Int32 id, DateTime create_time, DateTime update_time, String goods_sort_name, String goods_sort_describe)
        {
            this.id = id;
            this.create_time = create_time;
            this.update_time = update_time;
            this.goods_sort_name = goods_sort_name;
            this.goods_sort_describe = goods_sort_describe;
        }
        #endregion

        #region 属性

        private Int32 id;

        /// <summary>
        /// 
        /// </summary>
        [Id]
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime? create_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Create_time
        {
            get { return create_time; }
            set { create_time = value; }
        }

        private DateTime? update_time;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Update_time
        {
            get { return update_time; }
            set { update_time = value; }
        }

        private String goods_sort_name;

        /// <summary>
        /// 
        /// </summary>
        public String Goods_sort_name
        {
            get { return goods_sort_name; }
            set { goods_sort_name = value; }
        }

        private String goods_sort_describe;

        /// <summary>
        /// 
        /// </summary>
        public String Goods_sort_describe
        {
            get { return goods_sort_describe; }
            set { goods_sort_describe = value; }
        }
        #endregion

        #region 验证
        public List<string> ErrorList = new List<string>();
        private bool Validator()
        {
            bool validatorResult = true;
            if (this.Create_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Create_time should not be empty!");
            }
            if (this.Update_time == null)
            {
                validatorResult = false;
                this.ErrorList.Add("The Update_time should not be empty!");
            }
            if (string.IsNullOrEmpty(this.Goods_sort_name))
            {
                validatorResult = false;
                this.ErrorList.Add("The Goods_sort_name should not be empty!");
            }
            if (this.Goods_sort_name != null && 10 < this.Goods_sort_name.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Goods_sort_name should not be greater then 10!");
            }
            if (this.Goods_sort_describe != null && 10 < this.Goods_sort_describe.Length)
            {
                validatorResult = false;
                this.ErrorList.Add("The length of Goods_sort_describe should not be greater then 10!");
            }
            return validatorResult;
        }

        #endregion

        #region 辅助方法
        public Info_goods_sort Clone(bool isDeepCopy)
        {
            Info_goods_sort footman;
            if (isDeepCopy)
            {
                MemoryStream memoryStream = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                footman = (Info_goods_sort)formatter.Deserialize(memoryStream);
            }
            else
            {
                footman = (Info_goods_sort)this.MemberwiseClone();
            }
            return footman;
        }
        #endregion

    }
}
