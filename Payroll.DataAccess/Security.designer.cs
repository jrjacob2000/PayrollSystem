﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Payroll.DataAccess
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Payroll")]
	internal partial class SecurityDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertReference(Reference instance);
    partial void UpdateReference(Reference instance);
    partial void DeleteReference(Reference instance);
    partial void InsertAccount(Account instance);
    partial void UpdateAccount(Account instance);
    partial void DeleteAccount(Account instance);
    partial void InsertAccountProfile(AccountProfile instance);
    partial void UpdateAccountProfile(AccountProfile instance);
    partial void DeleteAccountProfile(AccountProfile instance);
    partial void InsertAccountHasRole(AccountHasRole instance);
    partial void UpdateAccountHasRole(AccountHasRole instance);
    partial void DeleteAccountHasRole(AccountHasRole instance);
    #endregion
		
		public SecurityDataContext() : 
				base(global::Payroll.DataAccess.Properties.Settings.Default.PayrollConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public SecurityDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SecurityDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SecurityDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SecurityDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<RoleCanPerform> RoleCanPerforms
		{
			get
			{
				return this.GetTable<RoleCanPerform>();
			}
		}
		
		public System.Data.Linq.Table<Reference> References
		{
			get
			{
				return this.GetTable<Reference>();
			}
		}
		
		public System.Data.Linq.Table<Account> Accounts
		{
			get
			{
				return this.GetTable<Account>();
			}
		}
		
		public System.Data.Linq.Table<AccountProfile> AccountProfiles
		{
			get
			{
				return this.GetTable<AccountProfile>();
			}
		}
		
		public System.Data.Linq.Table<AccountHasRole> AccountHasRoles
		{
			get
			{
				return this.GetTable<AccountHasRole>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.RoleCanPerform")]
	public partial class RoleCanPerform
	{
		
		private string _RoleCode;
		
		private string _OperationCode;
		
		public RoleCanPerform()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoleCode", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
		public string RoleCode
		{
			get
			{
				return this._RoleCode;
			}
			set
			{
				if ((this._RoleCode != value))
				{
					this._RoleCode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OperationCode", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
		public string OperationCode
		{
			get
			{
				return this._OperationCode;
			}
			set
			{
				if ((this._OperationCode != value))
				{
					this._OperationCode = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Reference")]
	public partial class Reference : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private string _ReferenceTypeCode;
		
		private string _ReferenceCode;
		
		private string _ReferenceValue;
		
		private System.Nullable<int> _Sequence;
		
		private System.Nullable<bool> _IsDeleted;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnReferenceTypeCodeChanging(string value);
    partial void OnReferenceTypeCodeChanged();
    partial void OnReferenceCodeChanging(string value);
    partial void OnReferenceCodeChanged();
    partial void OnReferenceValueChanging(string value);
    partial void OnReferenceValueChanged();
    partial void OnSequenceChanging(System.Nullable<int> value);
    partial void OnSequenceChanged();
    partial void OnIsDeletedChanging(System.Nullable<bool> value);
    partial void OnIsDeletedChanged();
    #endregion
		
		public Reference()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ReferenceTypeCode", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
		public string ReferenceTypeCode
		{
			get
			{
				return this._ReferenceTypeCode;
			}
			set
			{
				if ((this._ReferenceTypeCode != value))
				{
					this.OnReferenceTypeCodeChanging(value);
					this.SendPropertyChanging();
					this._ReferenceTypeCode = value;
					this.SendPropertyChanged("ReferenceTypeCode");
					this.OnReferenceTypeCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ReferenceCode", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
		public string ReferenceCode
		{
			get
			{
				return this._ReferenceCode;
			}
			set
			{
				if ((this._ReferenceCode != value))
				{
					this.OnReferenceCodeChanging(value);
					this.SendPropertyChanging();
					this._ReferenceCode = value;
					this.SendPropertyChanged("ReferenceCode");
					this.OnReferenceCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ReferenceValue", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
		public string ReferenceValue
		{
			get
			{
				return this._ReferenceValue;
			}
			set
			{
				if ((this._ReferenceValue != value))
				{
					this.OnReferenceValueChanging(value);
					this.SendPropertyChanging();
					this._ReferenceValue = value;
					this.SendPropertyChanged("ReferenceValue");
					this.OnReferenceValueChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sequence", DbType="Int")]
		public System.Nullable<int> Sequence
		{
			get
			{
				return this._Sequence;
			}
			set
			{
				if ((this._Sequence != value))
				{
					this.OnSequenceChanging(value);
					this.SendPropertyChanging();
					this._Sequence = value;
					this.SendPropertyChanged("Sequence");
					this.OnSequenceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsDeleted", DbType="Bit")]
		public System.Nullable<bool> IsDeleted
		{
			get
			{
				return this._IsDeleted;
			}
			set
			{
				if ((this._IsDeleted != value))
				{
					this.OnIsDeletedChanging(value);
					this.SendPropertyChanging();
					this._IsDeleted = value;
					this.SendPropertyChanged("IsDeleted");
					this.OnIsDeletedChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Account")]
	public partial class Account : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private string _UserName;
		
		private string _Email;
		
		private System.Guid _ProfileId;
		
		private string _Password;
		
		private System.Nullable<bool> _IsDeleted;
		
		private System.Nullable<System.DateTime> _CreatedDate;
		
		private System.Nullable<bool> _ChangePasswordOnFirstLogon;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnUserNameChanging(string value);
    partial void OnUserNameChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnProfileIdChanging(System.Guid value);
    partial void OnProfileIdChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnIsDeletedChanging(System.Nullable<bool> value);
    partial void OnIsDeletedChanged();
    partial void OnCreatedDateChanging(System.Nullable<System.DateTime> value);
    partial void OnCreatedDateChanged();
    partial void OnChangePasswordOnFirstLogonChanging(System.Nullable<bool> value);
    partial void OnChangePasswordOnFirstLogonChanged();
    #endregion
		
		public Account()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this.OnUserNameChanging(value);
					this.SendPropertyChanging();
					this._UserName = value;
					this.SendPropertyChanged("UserName");
					this.OnUserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(250)")]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProfileId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid ProfileId
		{
			get
			{
				return this._ProfileId;
			}
			set
			{
				if ((this._ProfileId != value))
				{
					this.OnProfileIdChanging(value);
					this.SendPropertyChanging();
					this._ProfileId = value;
					this.SendPropertyChanged("ProfileId");
					this.OnProfileIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="NVarChar(MAX)")]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsDeleted", DbType="Bit")]
		public System.Nullable<bool> IsDeleted
		{
			get
			{
				return this._IsDeleted;
			}
			set
			{
				if ((this._IsDeleted != value))
				{
					this.OnIsDeletedChanging(value);
					this.SendPropertyChanging();
					this._IsDeleted = value;
					this.SendPropertyChanged("IsDeleted");
					this.OnIsDeletedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedDate", DbType="Date")]
		public System.Nullable<System.DateTime> CreatedDate
		{
			get
			{
				return this._CreatedDate;
			}
			set
			{
				if ((this._CreatedDate != value))
				{
					this.OnCreatedDateChanging(value);
					this.SendPropertyChanging();
					this._CreatedDate = value;
					this.SendPropertyChanged("CreatedDate");
					this.OnCreatedDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChangePasswordOnFirstLogon", DbType="Bit")]
		public System.Nullable<bool> ChangePasswordOnFirstLogon
		{
			get
			{
				return this._ChangePasswordOnFirstLogon;
			}
			set
			{
				if ((this._ChangePasswordOnFirstLogon != value))
				{
					this.OnChangePasswordOnFirstLogonChanging(value);
					this.SendPropertyChanging();
					this._ChangePasswordOnFirstLogon = value;
					this.SendPropertyChanged("ChangePasswordOnFirstLogon");
					this.OnChangePasswordOnFirstLogonChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.AccountProfile")]
	public partial class AccountProfile : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private string _FirstName;
		
		private string _LastName;
		
		private string _FullName;
		
		private string _Title;
		
		private string _JobTitle;
		
		private System.Nullable<bool> _IsMale;
		
		private System.Nullable<bool> _IsDeleted;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnFullNameChanging(string value);
    partial void OnFullNameChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnJobTitleChanging(string value);
    partial void OnJobTitleChanged();
    partial void OnIsMaleChanging(System.Nullable<bool> value);
    partial void OnIsMaleChanged();
    partial void OnIsDeletedChanging(System.Nullable<bool> value);
    partial void OnIsDeletedChanged();
    #endregion
		
		public AccountProfile()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="NVarChar(255)")]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this.OnFirstNameChanging(value);
					this.SendPropertyChanging();
					this._FirstName = value;
					this.SendPropertyChanged("FirstName");
					this.OnFirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="NVarChar(255)")]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this.OnLastNameChanging(value);
					this.SendPropertyChanging();
					this._LastName = value;
					this.SendPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FullName", DbType="NVarChar(767)")]
		public string FullName
		{
			get
			{
				return this._FullName;
			}
			set
			{
				if ((this._FullName != value))
				{
					this.OnFullNameChanging(value);
					this.SendPropertyChanging();
					this._FullName = value;
					this.SendPropertyChanged("FullName");
					this.OnFullNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="NVarChar(255)")]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_JobTitle", DbType="NVarChar(255)")]
		public string JobTitle
		{
			get
			{
				return this._JobTitle;
			}
			set
			{
				if ((this._JobTitle != value))
				{
					this.OnJobTitleChanging(value);
					this.SendPropertyChanging();
					this._JobTitle = value;
					this.SendPropertyChanged("JobTitle");
					this.OnJobTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsMale", DbType="Bit")]
		public System.Nullable<bool> IsMale
		{
			get
			{
				return this._IsMale;
			}
			set
			{
				if ((this._IsMale != value))
				{
					this.OnIsMaleChanging(value);
					this.SendPropertyChanging();
					this._IsMale = value;
					this.SendPropertyChanged("IsMale");
					this.OnIsMaleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsDeleted", DbType="Bit")]
		public System.Nullable<bool> IsDeleted
		{
			get
			{
				return this._IsDeleted;
			}
			set
			{
				if ((this._IsDeleted != value))
				{
					this.OnIsDeletedChanging(value);
					this.SendPropertyChanging();
					this._IsDeleted = value;
					this.SendPropertyChanged("IsDeleted");
					this.OnIsDeletedChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.AccountHasRole")]
	public partial class AccountHasRole : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _AccountId;
		
		private string _RoleCode;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnAccountIdChanging(System.Guid value);
    partial void OnAccountIdChanged();
    partial void OnRoleCodeChanging(string value);
    partial void OnRoleCodeChanged();
    #endregion
		
		public AccountHasRole()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccountId", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid AccountId
		{
			get
			{
				return this._AccountId;
			}
			set
			{
				if ((this._AccountId != value))
				{
					this.OnAccountIdChanging(value);
					this.SendPropertyChanging();
					this._AccountId = value;
					this.SendPropertyChanged("AccountId");
					this.OnAccountIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoleCode", DbType="NVarChar(250) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string RoleCode
		{
			get
			{
				return this._RoleCode;
			}
			set
			{
				if ((this._RoleCode != value))
				{
					this.OnRoleCodeChanging(value);
					this.SendPropertyChanging();
					this._RoleCode = value;
					this.SendPropertyChanged("RoleCode");
					this.OnRoleCodeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
