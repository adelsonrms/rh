using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RH.Domain.Generic
{
    public class DbEntity<TClass> 
    {
        public EntityBase<TClass> DbEntityBase { get; set; }
        /// <summary>
        ///     Define a instancia da classe a ser analisada
        /// </summary>
        /// <param name="entityClass">Instancia da classe</param>
        public void Iniciatize(object entityClass)
        {
            DbEntityBase = new EntityBase<TClass>();
            DbEntityBase.KeyConvention = "ClassId";
            DbEntityBase.Iniciatize(entityClass);
        }

        /// <summary>
        ///     Representa a classe que deverá ser herdada por outras para obter informações automaticas das propriedades
        /// </summary>
        public class EntityBase<TEntityClass>
        {
            private List<Property> _properties;
            private object _thisEntityClass;
            private string _table;
            StringBuilder sbCampo = new StringBuilder();

            public TEntityClass Instance { get { return (TEntityClass)Activator.CreateInstance(typeof(TEntityClass)); } }

            public EntityBase()
            {
                this.KeyConvention = "ClassId";
            }
            public EntityBase(object entidade)
            {
                this.KeyConvention = "ClassId";
                this._thisEntityClass = entidade;
                this._table = entidade.GetType().Name;
            }
            public EntityBase(object entidade, string table = "")
            {
                if (entidade == null)
                {
                    entidade = this.Instance;
                }

                this.KeyConvention = "ClassId";
                this._thisEntityClass = entidade;
                this._table = table??entidade.GetType().Name.ToString();
                

                GetDataNotations();
                Iniciatize(entidade);
                RefreshProperties();

                if (this.KeyConvention == "ClassId")
                {
                    IdProperty = $"{this._table}Id";
                }
                else
                {
                    IdProperty = $"Id";
                }
            }
            private void GetDataNotations()
            {
                //var tableAtt = typeof(TEntityClass).GetCustomAttributes().ToList().Find(x => ((Type)x.TypeId).FullName == "System.ComponentModel.DataAnnotations.Schema.TableAttribute");
                var tableAtt = getCustomAtt(typeof(TEntityClass).GetCustomAttributes().ToList(), "TableAttribute");

                if (tableAtt!=null)
                {
                    this._table = tableAtt?.Name;
                }
            }
            public string IdProperty { get; set; }

            /// <summary>
            ///     Ao passar uma instancia de uma Classe, recupera a lista de propriedades da classe
            /// </summary>
            /// <param name="entityClass"></param>
            public List<Property> Properties
            {
                get
                {
                    if (_properties == null) _properties = RefreshProperties();
                    return _properties;
                }
            }
            /// <summary>
            ///     Define a instancia da classe a ser analisada
            /// </summary>
            /// <param name="entityClass">Instancia da classe</param>
            public void Iniciatize(object entityClass)
            {
                _thisEntityClass = entityClass;
            }
            /// <summary>
            ///     Usando Reflections.GetProperties, analisa as informações da Classe obtem os nomes e valores das propriedades
            /// </summary>
            /// <returns>Lista de Propriedades (Property)</returns>
            private List<Property> RefreshProperties()
            {
                _properties = new List<Property>();
                var list = typeof(TEntityClass).GetProperties().ToList();
                list.ForEach(p =>
                {
                    if ((p.ReflectedType.Name == _thisEntityClass.GetType().Name))
                    {
                        _properties.Add(new Property()
                        {
                            Name = GetPropertyName(p),
                            Value = GetMemberValue(_thisEntityClass, p),
                            DataType = p.PropertyType.Name
                        });
                    }
                });
                return _properties;
            }
            private string GetPropertyName(PropertyInfo p)
            {
                string pName = p.Name;
                dynamic columnAtt;

                columnAtt = getCustomAtt(p.GetCustomAttributes().ToList(), "ColumnAttribute");

                if (columnAtt!=null)
                {
                    return columnAtt?.Name;
                }

                columnAtt = getCustomAtt(p.GetCustomAttributes().ToList(), "KeyAttribute");

                if (columnAtt != null)
                {
                    this.KeyConvention = "Id";
                    IdProperty = p.Name;
                    return p.Name;
                }
                return pName;
            }
            private dynamic getCustomAtt(dynamic obj, string type)
            {
                List<Attribute> attL = obj; 

                if (attL.Count>0)
                {
                    var att = attL.Find(x => ((Type)x.TypeId).Name == type);
                    return ((dynamic)att);
                }
                else
                {
                    return null;
                }
            }
            /// <summary>
            ///     Obtem o valor de uma propriedade a informar o nome
            /// </summary>
            /// <param name="pName">Nome da Propriedade</param>
            /// <returns>Retorna o conteudo da propriedade</returns>
            public object GetValue(string pName)
            {
                var propMember = _thisEntityClass.GetType().GetProperty(pName);
                return GetMemberValue(_thisEntityClass, propMember);
            }
            /// <summary>
            ///     Salva um valor na propriedae
            /// </summary>
            /// <param name="pName">Nome da Propriedae</param>
            /// <param name="pValue">Valor a ser salvo</param>
            public void SetValue(string pName, object pValue)
            {
                var propMember = _thisEntityClass.GetType().GetProperty(pName);
                SetMemberValue(_thisEntityClass, propMember, pValue);
            }
            /// <summary>
            ///     Metodo abstrato que salva o valor proprieamente dito no objeto da classe atraves da função membro.GetValue()
            /// </summary>
            /// <param name="objeto">Instancia do Objeto</param>
            /// <param name="membro">Instancia do membro do objeto</param>
            /// <param name="valor">Valor</param>
            private void SetMemberValue(object objeto, PropertyInfo membro, object valor)
            {
                try
                {
                    if (membro.GetGetMethod().IsStatic)
                        membro.SetValue(null, valor, null);
                    else
                        membro.SetValue(objeto, valor, null);
                }
                catch (Exception ex)
                {
                    throw new Exception("setMemberValue() - Erro :" + ex.Message);
                }
            }
            /// <summary>
            ///     Recupera o valor de um membro de uma classe (Normalmente Propriedade) atraves da função membro.GetValue()
            /// </summary>
            /// <param name="objeto">Instancia do Objeto</param>
            /// <param name="membro">Instancia do membro do objeto</param>
            /// <returns></returns>
            private object GetMemberValue(object objeto, PropertyInfo membro)
            {
                if (membro.GetGetMethod().IsStatic)
                    return membro.GetValue(null, null);
                return membro.GetValue(objeto, null);
            }
            private object GetTSQLValue(string pName)
            {
                {
                    Property p = this.Properties.Find(a => a.Name == pName);
                    switch (p.DataType.ToLower())
                    {
                        case "string": case "guid": return "'" + p.Value.ToString() + "'";
                        case "date": return "#" + p.Value + "#";
                        default: return p.Value.ToString();
                    };
                }
                            ;
            }
            private string TrataCampo(string idName)
            {
                string id = $"[{idName}]";
                if (KeyConvention == "ClassId" && idName == "Id")
                {
                    if (ToTable.Contains("."))
                    {
                        id = $"[{ToTable.Split(".".ToArray())[1]}{idName}]";
                    }
                    else
                    {
                        id = $"[{ToTable}{idName}]";
                    }
                };
                return id;
            }
            private string WhereId()
            {
                return $"WHERE {TrataCampo("Id")} = {GetTSQLValue("Id")}";
            }
            private string SelectFields
            {
                get
                {
                    sbCampo = new StringBuilder();

                    this.Properties.ForEach(p =>
                    {
                        if (p.Name == "Id")
                        {
                            sbCampo.Append($",{TrataCampo(p.Name)} AS Id");
                        }
                        else
                        {
                            sbCampo.Append($",{TrataCampo(p.Name)} ");
                        };
                    });
                    return sbCampo.Remove(0, 1).ToString().Trim();
                }
            }
            private string InsertFields
            {
                get
                {
                    sbCampo = new StringBuilder();
                    this.Properties.Where(pr => !pr.Name.ToLower().Contains("ordem")).ToList().ForEach(p =>
                    {
                        sbCampo.Append($",{TrataCampo(p.Name)} ");
                    });
                    return sbCampo.Remove(0, 1).ToString().Trim();
                }
            }
            private string InsertValues
            {
                get
                {
                    sbCampo = new StringBuilder();
                    this.Properties.Where(pr => !pr.Name.ToLower().Contains("ordem")).ToList().ForEach(p =>
                    {
                        sbCampo.Append($",{GetTSQLValue(p.Name)} ");
                    });
                    return sbCampo.Remove(0, 1).ToString();
                }
            }
            private string UpdateFields
            {
                get
                {
                    sbCampo = new StringBuilder();
                    this.Properties.Where(pr => !pr.Name.ToLower().Contains("ordem")).ToList().ForEach(p =>
                    {
                        sbCampo.Append($",{TrataCampo(p.Name)} = {GetTSQLValue(p.Name)} ");
                    });
                    return sbCampo.Remove(0, 1).ToString().Trim();
                }
            }

            #region "Consultas SELECT abstraidas"
            /// <summary>
            ///     Recupera a String do SELECT ALL FROM TABLE referente à classe
            /// </summary>
            private string SelectAll => $"SELECT {SelectFields} FROM {ToTable}";
            public string Select() => $"{SelectAll} {WhereId()}";
            public string Select(bool all = false)
            {
                if (all)
                {
                    return SelectAll;
                }
                else
                {
                    return Select();
                }
            }
            public string Delete(bool all = false)
            {
                if (all)
                {
                    return $"DELETE FROM {ToTable}";
                }
                else
                {
                    return $"DELETE FROM {ToTable} {WhereId()}";
                }
            }

            public string Update() => $"UPDATE {ToTable} SET {UpdateFields} {WhereId()}";
            public string Insert() => $"INSERT INTO {ToTable} ({InsertFields}) VALUES ({InsertValues})";
            public string ToTable { get { return _table == null ? _thisEntityClass.GetType().Name : _table; } set { _table = value; } }
            public string KeyConvention { get; set; }
            public object SqlCrud
            {
                get
                {
                    try
                    {
                        return new
                        {
                            InsertCommand = this.Insert(),
                            SelectCommand = this.Select(),
                            UpdateCommand = this.Update(),
                            DeleteCommand = this.Delete()
                        };
                    }
                    catch
                    {
                        return new
                        {
                            InsertCommand = "(Exception)",
                            SelectCommand = "(Exception)",
                            UpdateCommand = "(Exception)",
                            DeleteCommand = "(Exception)"
                        };
                    }

                }
            }

            public string SelectById(string id)
            {
                return SelectByCollumn(IdProperty, id);
            }

            public string SelectByCollumn(string fieldName, string fieldValue)
            {
                return $"{Select(true)} WHERE {fieldName}='{fieldValue}'";
            }
            #endregion
        }

    }


    /// <summary>
    ///     Representa a classe que deverá ser herdada por outras para obter informações automaticas das propriedades
    /// </summary>
    public class EntityClass<TEntityClass>
    {
        private List<Property> _properties;
        private object _instance;

        public TEntityClass Instance { get { return (TEntityClass)Activator.CreateInstance(typeof(TEntityClass)); } }
        public EntityClass()
        {
            RefreshProperties();
        }
        public EntityClass(object entidade)
        {
            this._instance = entidade;
            RefreshProperties();
        }
        public EntityClass(object entidade, string table = "")
        {
            if (entidade == null)
            {
                entidade = this.Instance;
            }

            this._instance = entidade;
            Iniciatize(entidade);
            RefreshProperties();
        }
        /// <summary>
        ///     Ao passar uma instancia de uma Classe, recupera a lista de propriedades da classe
        /// </summary>
        /// <param name="entityClass"></param>
        public List<Property> Properties
        {
            get
            {
                if (_properties == null) _properties = RefreshProperties();
                return _properties;
            }
        }
        /// <summary>
        ///     Define a instancia da classe a ser analisada
        /// </summary>
        /// <param name="entityClass">Instancia da classe</param>
        public void Iniciatize(object entityClass)
        {
            _instance = entityClass;
        }
        /// <summary>
        ///     Usando Reflections.GetProperties, analisa as informações da Classe obtem os nomes e valores das propriedades
        /// </summary>
        /// <returns>Lista de Propriedades (Property)</returns>
        private List<Property> RefreshProperties()
        {
            _properties = new List<Property>();
            var list = _instance.GetType().GetProperties().ToList();
            list.ForEach(p =>
            {
                if ((p.ReflectedType.Name == _instance.GetType().Name))
                {
                    _properties.Add(new Property()
                    {
                        Name = p.Name,
                        Value = GetMemberValue(_instance, p),
                        DataType = p.PropertyType.Name
                    });
                }
            });
            return _properties;
        }
        /// <summary>
        ///     Obtem o valor de uma propriedade a informar o nome
        /// </summary>
        /// <param name="pName">Nome da Propriedade</param>
        /// <returns>Retorna o conteudo da propriedade</returns>
        public object GetValue(string pName)
        {
            var propMember = _instance.GetType().GetProperty(pName);
            return GetMemberValue(_instance, propMember);
        }
        /// <summary>
        ///     Salva um valor na propriedae
        /// </summary>
        /// <param name="pName">Nome da Propriedae</param>
        /// <param name="pValue">Valor a ser salvo</param>
        public void SetValue(string pName, object pValue)
        {
            var propMember = _instance.GetType().GetProperty(pName);
            SetMemberValue(_instance, propMember, pValue);
        }
        /// <summary>
        ///     Metodo abstrato que salva o valor proprieamente dito no objeto da classe atraves da função membro.GetValue()
        /// </summary>
        /// <param name="objeto">Instancia do Objeto</param>
        /// <param name="membro">Instancia do membro do objeto</param>
        /// <param name="valor">Valor</param>
        private void SetMemberValue(object objeto, PropertyInfo membro, object valor)
        {
            try
            {
                if (membro.GetGetMethod().IsStatic)
                    membro.SetValue(null, valor, null);
                else
                    membro.SetValue(objeto, valor, null);
            }
            catch (Exception ex)
            {
                throw new Exception("setMemberValue() - Erro :" + ex.Message);
            }
        }
        /// <summary>
        ///     Recupera o valor de um membro de uma classe (Normalmente Propriedade) atraves da função membro.GetValue()
        /// </summary>
        /// <param name="objeto">Instancia do Objeto</param>
        /// <param name="membro">Instancia do membro do objeto</param>
        /// <returns></returns>
        private object GetMemberValue(object objeto, PropertyInfo membro)
        {
            if (membro.GetGetMethod().IsStatic)
                return membro.GetValue(null, null);
            return membro.GetValue(objeto, null);
        }
    }

    /// <summary>
    ///     Representa uma Propriedade generica
    /// </summary>
    public class Property
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public string DataType { get; set; }
    }
}