/**  Class Info。
* DogDao.cs
*
* 功 能： N/A
* 类 名： DogDao
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  9/16/2020 9:17:38 PM   N/A    初版
*
* Copyright (c) 2020. All rights reserved.
* ───────────────────────────────────
*/
using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using DogApi.Tool;//Please add references
namespace DogApi.DAL
{
	/// <summary>
	/// 数据访问类:DogDao
	/// </summary>
	public partial class DogDao
	{
		public DogDao()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("dogid", "dog"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int dogid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dog");
			strSql.Append(" where dogid=@dogid ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@dogid", DbType.Int32,4)			};
			parameters[0].Value = dogid;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DogApi.Model.DogModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dog(");
			strSql.Append("dogid,name,age,typeid,lat,lng,alt,userName)");
			strSql.Append(" values (");
			strSql.Append("@dogid,@name,@age,@typeid,@lat,@lng,@alt,@userName)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@dogid", DbType.Int32,4),
					new SQLiteParameter("@name", DbType.String,50),
					new SQLiteParameter("@age", DbType.Int32,4),
					new SQLiteParameter("@typeid", DbType.Int32,4),
					new SQLiteParameter("@lat", DbType.Double,8),
					new SQLiteParameter("@lng", DbType.Double,8),
					new SQLiteParameter("@alt", DbType.Double,8),
					new SQLiteParameter("@userName", DbType.String,50)};
			parameters[0].Value = GetMaxId();
			parameters[1].Value = model.name;
			parameters[2].Value = model.age;
			parameters[3].Value = model.typeid;
			parameters[4].Value = model.lat;
			parameters[5].Value = model.lng;
			parameters[6].Value = model.alt;
			parameters[7].Value = model.userName;

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DogApi.Model.DogModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dog set ");
			strSql.Append("name=@name,");
			strSql.Append("age=@age,");
			strSql.Append("typeid=@typeid,");
			strSql.Append("lat=@lat,");
			strSql.Append("lng=@lng,");
			strSql.Append("alt=@alt,");
			strSql.Append("userName=@userName");
			strSql.Append(" where dogid=@dogid ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@name", DbType.String,50),
					new SQLiteParameter("@age", DbType.Int32,4),
					new SQLiteParameter("@typeid", DbType.Int32,4),
					new SQLiteParameter("@lat", DbType.Double,8),
					new SQLiteParameter("@lng", DbType.Double,8),
					new SQLiteParameter("@alt", DbType.Double,8),
					new SQLiteParameter("@userName", DbType.String,50),
					new SQLiteParameter("@dogid", DbType.Int32,4)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.age;
			parameters[2].Value = model.typeid;
			parameters[3].Value = model.lat;
			parameters[4].Value = model.lng;
			parameters[5].Value = model.alt;
			parameters[6].Value = model.userName;
			parameters[7].Value = model.dogid;

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int dogid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from dog ");
			strSql.Append(" where dogid=@dogid ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@dogid", DbType.Int32,4)			};
			parameters[0].Value = dogid;

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string dogidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from dog ");
			strSql.Append(" where dogid in ("+dogidlist + ")  ");
			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DogApi.Model.DogModel GetModel(int dogid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select dogid,name,age,typeid,lat,lng,alt,userName from dog ");
			strSql.Append(" where dogid=@dogid ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@dogid", DbType.Int32,4)			};
			parameters[0].Value = dogid;

			DogApi.Model.DogModel model=new DogApi.Model.DogModel();
			DataSet ds=DbHelperSQLite.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DogApi.Model.DogModel DataRowToModel(DataRow row)
		{
			DogApi.Model.DogModel model=new DogApi.Model.DogModel();
			if (row != null)
			{
				if(row["dogid"]!=null && row["dogid"].ToString()!="")
				{
					model.dogid=int.Parse(row["dogid"].ToString());
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["age"]!=null && row["age"].ToString()!="")
				{
					model.age=int.Parse(row["age"].ToString());
				}
				if(row["typeid"]!=null && row["typeid"].ToString()!="")
				{
					model.typeid=int.Parse(row["typeid"].ToString());
				}
					//model.lat=row["lat"].ToString();
					//model.lng=row["lng"].ToString();
					//model.alt=row["alt"].ToString();
				if(row["userName"]!=null)
				{
					model.userName=row["userName"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select dogid,name,age,typeid,lat,lng,alt,userName ");
			strSql.Append(" FROM dog ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQLite.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM dog ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQLite.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.dogid desc");
			}
			strSql.Append(")AS Row, T.*  from dog T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQLite.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@tblName", DbType.VarChar, 255),
					new SQLiteParameter("@fldName", DbType.VarChar, 255),
					new SQLiteParameter("@PageSize", DbType.Int32),
					new SQLiteParameter("@PageIndex", DbType.Int32),
					new SQLiteParameter("@IsReCount", DbType.bit),
					new SQLiteParameter("@OrderType", DbType.bit),
					new SQLiteParameter("@strWhere", DbType.VarChar,1000),
					};
			parameters[0].Value = "dog";
			parameters[1].Value = "dogid";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQLite.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

