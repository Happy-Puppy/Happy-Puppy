/**  Class Info。
* ActivityDao.cs
*
* 功 能： N/A
* 类 名： ActivityDao
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
	/// 数据访问类:ActivityDao
	/// </summary>
	public partial class ActivityDao
	{
		public ActivityDao()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("actid", "activity"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int actid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from activity");
			strSql.Append(" where actid=@actid ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@actid", DbType.Int32,4)			};
			parameters[0].Value = actid;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DogApi.Model.ActivityModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into activity(");
			strSql.Append("actid,name,note,lat,lng,alt,userName)");
			strSql.Append(" values (");
			strSql.Append("@actid,@name,@note,@lat,@lng,@alt,@userName)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@actid", DbType.Int32,4),
					new SQLiteParameter("@name", DbType.String,50),
					new SQLiteParameter("@note", DbType.String,500),
					new SQLiteParameter("@lat", DbType.Double,8),
					new SQLiteParameter("@lng", DbType.Double,8),
					new SQLiteParameter("@alt", DbType.Double,8),
					new SQLiteParameter("@userName", DbType.String,50)};
			parameters[0].Value = model.actid;
			parameters[1].Value = model.name;
			parameters[2].Value = model.note;
			parameters[3].Value = model.lat;
			parameters[4].Value = model.lng;
			parameters[5].Value = model.alt;
			parameters[6].Value = model.userName;

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
		public bool Update(DogApi.Model.ActivityModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update activity set ");
			strSql.Append("name=@name,");
			strSql.Append("note=@note,");
			strSql.Append("lat=@lat,");
			strSql.Append("lng=@lng,");
			strSql.Append("alt=@alt,");
			strSql.Append("userName=@userName");
			strSql.Append(" where actid=@actid ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@name", DbType.String,50),
					new SQLiteParameter("@note", DbType.String,500),
					new SQLiteParameter("@lat", DbType.Double,8),
					new SQLiteParameter("@lng", DbType.Double,8),
					new SQLiteParameter("@alt", DbType.Double,8),
					new SQLiteParameter("@userName", DbType.String,50),
					new SQLiteParameter("@actid", DbType.Int32,4)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.note;
			parameters[2].Value = model.lat;
			parameters[3].Value = model.lng;
			parameters[4].Value = model.alt;
			parameters[5].Value = model.userName;
			parameters[6].Value = model.actid;

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
		public bool Delete(int actid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from activity ");
			strSql.Append(" where actid=@actid ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@actid", DbType.Int32,4)			};
			parameters[0].Value = actid;

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
		public bool DeleteList(string actidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from activity ");
			strSql.Append(" where actid in ("+actidlist + ")  ");
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
		public DogApi.Model.ActivityModel GetModel(int actid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select actid,name,note,lat,lng,alt,userName from activity ");
			strSql.Append(" where actid=@actid ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@actid", DbType.Int32,4)			};
			parameters[0].Value = actid;

			DogApi.Model.ActivityModel model=new DogApi.Model.ActivityModel();
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
		public DogApi.Model.ActivityModel DataRowToModel(DataRow row)
		{
			DogApi.Model.ActivityModel model=new DogApi.Model.ActivityModel();
			if (row != null)
			{
				if(row["actid"]!=null && row["actid"].ToString()!="")
				{
					model.actid=int.Parse(row["actid"].ToString());
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["note"]!=null)
				{
					model.note=row["note"].ToString();
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
			strSql.Append("select actid,name,note,lat,lng,alt,userName ");
			strSql.Append(" FROM activity ");
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
			strSql.Append("select count(1) FROM activity ");
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
				strSql.Append("order by T.actid desc");
			}
			strSql.Append(")AS Row, T.*  from activity T ");
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
			parameters[0].Value = "activity";
			parameters[1].Value = "actid";
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

