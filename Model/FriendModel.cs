/**  Class Info。
* FriendModel.cs
*
* 功 能： N/A
* 类 名： FriendModel
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  9/16/2020 9:17:38 PM   N/A    初版
*
* Copyright (c) 2020. All rights reserved.
* ───────────────────────────────────
*/
using System;
namespace DogApi.Model
{
	/// <summary>
	/// FriendModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class FriendModel
	{
		public FriendModel()
		{}
		#region Model
		private int _fid;
		private string _username;
		private string _fusername;
		/// <summary>
		/// 
		/// </summary>
		public int fid
		{
			set{ _fid=value;}
			get{return _fid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fusername
		{
			set{ _fusername=value;}
			get{return _fusername;}
		}
		#endregion Model

	}
}

