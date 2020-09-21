/**  Class Info。
* FriendDao.cs
*
* 功 能： N/A
* 类 名： FriendDao
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
	/// 数据访问类:FriendDao
	/// </summary>
	public partial class FriendDao
	{
		public FriendDao()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("fid", "friend"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int fid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from friend");
			strSql.Append(" where fid=@fid ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@fid", DbType.Int32,4)			};
			parameters[0].Value = fid;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DogApi.Model.FriendModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into friend(");
			strSql.Append("fid,username,fusername)");
			strSql.Append(" values (");
			strSql.Append("@fid,@username,@fusername)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@fid", DbType.Int32,4),
					new SQLiteParameter("@username", DbType.String,50),
					new SQLiteParameter("@fusername", DbType.String,50)};
			parameters[0].Value = model.fid;
			parameters[1].Value = model.username;
			parameters[2].Value = model.fusername;

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
		public bool Update(DogApi.Model.FriendModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update friend set ");
			strSql.Append("username=@username,");
			strSql.Append("fusername=@fusername");
			strSql.Append(" where fid=@fid ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@username", DbType.String,50),
					new SQLiteParameter("@fusername", DbType.String,50),
					new SQLiteParameter("@fid", DbType.Int32,4)};
			parameters[0].Value = model.username;
			parameters[1].Value = model.fusername;
			parameters[2].Value = model.fid;

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
		public bool Delete(int fid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from friend ");
			strSql.Append(" where fid=@fid ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@fid", DbType.Int32,4)			};
			parameters[0].Value = fid;

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
		public bool DeleteList(string fidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from friend ");
			strSql.Append(" where fid in ("+fidlist + ")  ");
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
		public DogApi.Model.FriendModel GetModel(int fid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select fid,username,fusername from friend ");
			strSql.Append(" where fid=@fid ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@fid", DbType.Int32,4)			};
			parameters[0].Value = fid;

			DogApi.Model.FriendModel model=new DogApi.Model.FriendModel();
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
		public DogApi.Model.FriendModel DataRowToModel(DataRow row)
		{
			DogApi.Model.FriendModel model=new DogApi.Model.FriendModel();
			if (row != null)
			{
				if(row["fid"]!=null && row["fid"].ToString()!="")
				{
					model.fid=int.Parse(row["fid"].ToString());
				}
				if(row["username"]!=null)
				{
					model.username=row["username"].ToString();
				}
				if(row["fusername"]!=null)
				{
					model.fusername=row["fusername"].ToString();
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
			strSql.Append("select fid,username,fusername ");
			strSql.Append(" FROM friend ");
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
			strSql.Append("select count(1) FROM friend ");
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
				strSql.Append("order by T.fid desc");
			}
			strSql.Append(")AS Row, T.*  from friend T ");
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
			parameters[0].Value = "friend";
			parameters[1].Value = "fid";
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

