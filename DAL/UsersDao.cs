/**  Class Info。
* UsersDao.cs
*
* 功 能： N/A
* 类 名： UsersDao
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  9/24/2020 11:27:54 PM   N/A    初版
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
	/// 数据访问类:UsersDao
	/// </summary>
	public partial class UsersDao
	{
		public UsersDao()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string userName)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from users");
			strSql.Append(" where userName=@userName ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@userName", DbType.String,25)			};
			parameters[0].Value = userName;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DogApi.Model.UsersModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into users(");
			strSql.Append("userName,passWord,lat,lng,alt,tel,age)");
			strSql.Append(" values (");
			strSql.Append("@userName,@passWord,@lat,@lng,@alt,@tel,@age)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@userName", DbType.String,25),
					new SQLiteParameter("@passWord", DbType.String,50),
					new SQLiteParameter("@lat", DbType.Double,8),
					new SQLiteParameter("@lng", DbType.Double,8),
					new SQLiteParameter("@alt", DbType.Double,8),
					new SQLiteParameter("@tel", DbType.String,30),
					new SQLiteParameter("@age", DbType.Int32,8)};
			parameters[0].Value = model.userName;
			parameters[1].Value = model.passWord;
			parameters[2].Value = model.lat;
			parameters[3].Value = model.lng;
			parameters[4].Value = model.alt;
			parameters[5].Value = model.tel;
			parameters[6].Value = model.age;

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
		public bool Update(DogApi.Model.UsersModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update users set ");
			strSql.Append("passWord=@passWord,");
			strSql.Append("lat=@lat,");
			strSql.Append("lng=@lng,");
			strSql.Append("alt=@alt,");
			strSql.Append("tel=@tel,");
			strSql.Append("age=@age");
			strSql.Append(" where userName=@userName ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@passWord", DbType.String,50),
					new SQLiteParameter("@lat", DbType.Double,8),
					new SQLiteParameter("@lng", DbType.Double,8),
					new SQLiteParameter("@alt", DbType.Double,8),
					new SQLiteParameter("@tel", DbType.String,30),
					new SQLiteParameter("@age", DbType.Int32,8),
					new SQLiteParameter("@userName", DbType.String,25)};
			parameters[0].Value = model.passWord;
			parameters[1].Value = model.lat;
			parameters[2].Value = model.lng;
			parameters[3].Value = model.alt;
			parameters[4].Value = model.tel;
			parameters[5].Value = model.age;
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(string userName)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from users ");
			strSql.Append(" where userName=@userName ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@userName", DbType.String,25)			};
			parameters[0].Value = userName;

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
		public bool DeleteList(string userNamelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from users ");
			strSql.Append(" where userName in ("+userNamelist + ")  ");
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
		public DogApi.Model.UsersModel GetModel(string userName)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select userName,passWord,lat,lng,alt,tel,age from users ");
			strSql.Append(" where userName=@userName ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@userName", DbType.String,25)			};
			parameters[0].Value = userName;

			DogApi.Model.UsersModel model=new DogApi.Model.UsersModel();
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
		public DogApi.Model.UsersModel DataRowToModel(DataRow row)
		{
			DogApi.Model.UsersModel model=new DogApi.Model.UsersModel();
			if (row != null)
			{
				if(row["userName"]!=null)
				{
					model.userName=row["userName"].ToString();
				}
				if(row["passWord"]!=null)
				{
					model.passWord=row["passWord"].ToString();
				}
					//model.lat=row["lat"].ToString();
					//model.lng=row["lng"].ToString();
					//model.alt=row["alt"].ToString();
				if(row["tel"]!=null)
				{
					model.tel=row["tel"].ToString();
				}
				if(row["age"]!=null && row["age"].ToString()!="")
				{
					model.age=int.Parse(row["age"].ToString());
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
			strSql.Append("select userName,passWord,lat,lng,alt,tel,age ");
			strSql.Append(" FROM users ");
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
			strSql.Append("select count(1) FROM users ");
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
				strSql.Append("order by T.userName desc");
			}
			strSql.Append(")AS Row, T.*  from users T ");
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
			parameters[0].Value = "users";
			parameters[1].Value = "userName";
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

