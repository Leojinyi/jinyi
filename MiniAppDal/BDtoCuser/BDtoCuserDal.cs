using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using MiniAppModel;
using MiniAppModel.LeadData;
using System.Threading.Tasks;
using MiniAppDal.Extensions;

namespace MiniAppDal.BDtoCuser
{

    public class BDtoCuserDal
    {
        public string connStr = ConfigurationManager.ConnectionStrings["DbContext"].ConnectionString;

        #region private utility methods & constructors
        static BDtoCuserDal _instance;
        static object _lock = new object();
        string _conn = string.Empty;
        public static BDtoCuserDal Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new BDtoCuserDal();
                    }
                }
                return _instance;
            }
        }

        private BDtoCuserDal()
        {
            _conn = ConfigurationManager.ConnectionStrings["DbContext"].ConnectionString;
        }
        #endregion
        /// <summary>
        /// 查询地推下渠道发展的c类用户
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns></returns>
        public async Task<BDtoCuserList> GetBDtoCuserList(string startTime, string endTime)
        {
            string sql = string.Format(@"with dtbd as 
                             (select wx_open_id,ue.name from user_main um 
                              inner join user_type ut on um.id=ut.user_id
                              INNER JOIN dbo.user_extra ue ON um.id=ue.user_id 
                              WHERE ut.user_type =0 and um.is_available =0),
                             dtqd as 
                             (select um.wx_open_id,um.wx_open_id_b,dtbd.name from dtbd  
                              INNER join user_main um on dtbd.wx_open_id = um.wx_open_id_b 
                              INNER join user_type ut on um.id = ut.user_id where ut.user_type=1)
                              SELECT count(dtqd.wx_open_id_b) AS num,dtqd.name AS name,convert(varchar(10),um.create_time,120) as dates from dtqd 
                              INNER join user_main um on dtqd.wx_open_id=um.wx_open_id_b
                              INNER join user_type ut on um.id = ut.user_id
                              where ut.user_type =3 AND um.create_time BETWEEN '{0}' AND '{1}'
                              GROUP by dtqd.name,convert(varchar(10),um.create_time,120)
                              ORDER BY convert(varchar(10),um.create_time,120) asc", startTime, endTime);
            //using (SqlConnection db = new SqlConnection(connStr))
            //{
            //    return db.Query<BDtoCuserEntity>(sql).AsList();
            //}
            BDtoCuserEntity temp = null;
            BDtoCuserList result = new BDtoCuserList
            {
                list = new List<BDtoCuserEntity>()
            };
            var list = await DapperHelper.GetListAsync<BDtoCuserEntity>(sql, this._conn);

            foreach (var item in list)
            {
                temp = new BDtoCuserEntity
                {
                    dates =item.dates,//.Insert(4, "-").Insert(7, "-"),
                    num = item.num,
                    name = item.name
                };
                result.list.Add(temp);
            }
            return result ?? null;
        }

        public async Task<BDtoCuserList> GetBDtoCuserNameList()
        {
            string sql = string.Format(@"WITH dtbd as (
                                   select wx_open_id,name,ue.create_time from user_main um 
                                   inner join user_type ut on um.id=ut.user_id
                                   inner join user_extra ue on um.id=ue.user_id
                                   where ut.user_type =0 and um.is_available =0)
                                   SELECT dtbd.name AS name from dtbd 
                                   inner join user_main um on dtbd.wx_open_id = um.wx_open_id_b 
                                   inner join user_type ut on um.id = ut.user_id
                                   where ut.user_type=1
                                   group BY dtbd.wx_open_id,dtbd.name,convert(varchar(10),dtbd.create_time,120)
								   ORDER BY convert(varchar(10),dtbd.create_time,120) ASC");
            BDtoCuserEntity temp = null;
            BDtoCuserList result = new BDtoCuserList
            {
                list = new List<BDtoCuserEntity>()
            };
            var list = await DapperHelper.GetListAsync<BDtoCuserEntity>(sql, this._conn);

            foreach (var item in list)
            {
                temp = new BDtoCuserEntity
                {
                    name = item.name
                };
                result.list.Add(temp);
            }
            return result ?? null;
        }
        
    }

}
