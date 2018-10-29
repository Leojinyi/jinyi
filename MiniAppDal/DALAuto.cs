using DapperEx;
using MiniAppApis.MiniAppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppApis.MiniAppDal
{

    public partial class goods_pictureDAL : DataAccessBase<Info_goods_picture>
    {
        public goods_pictureDAL(DbBase db) : base(db) { }
    }
    public partial class user_extraDAL : DataAccessBase<Info_user_extra>
    {
        public user_extraDAL(DbBase db) : base(db) { }
    }
    public partial class accountDAL : DataAccessBase<Info_account>
    {
        public accountDAL(DbBase db) : base(db) { }
    }
    public partial class account_logDAL : DataAccessBase<Info_account_log>
    {
        public account_logDAL(DbBase db) : base(db) { }
    }
    public partial class user_mainDAL : DataAccessBase<Info_user_main>
    {
        public user_mainDAL(DbBase db) : base(db) { }
    }
    public partial class profitDAL : DataAccessBase<Info_profit>
    {
        public profitDAL(DbBase db) : base(db) { }
    }
    public partial class msgtemplatecontentDAL : DataAccessBase<Info_msgtemplatecontent>
    {
        public msgtemplatecontentDAL(DbBase db) : base(db) { }
    }
    public partial class dic_messageDAL : DataAccessBase<Info_dic_message>
    {
        public dic_messageDAL(DbBase db) : base(db) { }
    }
    public partial class msgtemplatetypeDAL : DataAccessBase<Info_msgtemplatetype>
    {
        public msgtemplatetypeDAL(DbBase db) : base(db) { }
    }
    public partial class goods_specificationsDAL : DataAccessBase<Info_goods_specifications>
    {
        public goods_specificationsDAL(DbBase db) : base(db) { }
    }
    public partial class user_typeDAL : DataAccessBase<Info_user_type>
    {
        public user_typeDAL(DbBase db) : base(db) { }
    }
    public partial class order_mainDAL : DataAccessBase<Info_order_main>
    {
        public order_mainDAL(DbBase db) : base(db) { }
    }
    public partial class order_pay_infoDAL : DataAccessBase<Info_order_pay_info>
    {
        public order_pay_infoDAL(DbBase db) : base(db) { }
    }
    public partial class user_b2cDAL : DataAccessBase<Info_user_b2c>
    {
        public user_b2cDAL(DbBase db) : base(db) { }
    }
    public partial class user_pickup_infoDAL : DataAccessBase<Info_user_pickup_info>
    {
        public user_pickup_infoDAL(DbBase db) : base(db) { }
    }
    public partial class user_pictureDAL : DataAccessBase<Info_user_picture>
    {
        public user_pictureDAL(DbBase db) : base(db) { }
    }
    public partial class user_shopDAL : DataAccessBase<Info_user_shop>
    {
        public user_shopDAL(DbBase db) : base(db) { }
    }
    public partial class order_pickup_infoDAL : DataAccessBase<Info_order_pickup_info>
    {
        public order_pickup_infoDAL(DbBase db) : base(db) { }
    }
    public partial class order_goodsDAL : DataAccessBase<Info_order_goods>
    {
        public order_goodsDAL(DbBase db) : base(db) { }
    }
    public partial class order_logDAL : DataAccessBase<Info_order_log>
    {
        public order_logDAL(DbBase db) : base(db) { }
    }
    public partial class goodsDAL : DataAccessBase<Info_goods>
    {
        public goodsDAL(DbBase db) : base(db) { }
    }
    public partial class goods_sortDAL : DataAccessBase<Info_goods_sort>
    {
        public goods_sortDAL(DbBase db) : base(db) { }
    }
}
