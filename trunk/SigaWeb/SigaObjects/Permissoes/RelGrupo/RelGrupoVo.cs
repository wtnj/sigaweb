using System;
using System.Collections.Generic;
using System.Text;

namespace SigaObjects.Permissoes.RelGrupo
{
    public class RelGrupoVo
    {
        private int id, idUserGroup, idReport, nivel;

        #region Getters & Setters
        public int ID
        {
            get { return id; }
            set { this.id = value; }
        }
        public int IDUSERGROUP
        {
            get { return idUserGroup; }
            set { this.idUserGroup = value; }
        }
        public int IDREPORT
        {
            get { return idReport; }
            set { this.idReport = value; }
        }
        public int NIVEL
        {
            get { return nivel; }
            set { this.nivel = value; }
        }
        #endregion

        #region Contrutores
        public RelGrupoVo() { }
        public RelGrupoVo(int id)
        {
            this.ID = id;
        }
        public RelGrupoVo(int idUserGroup, int idReport, int nivel)
        {
            this.IDUSERGROUP = idUserGroup;
            this.IDREPORT = idReport;
            this.NIVEL = nivel;
        }
        public RelGrupoVo(int id, int idUserGroup, int idReport, int nivel)
        {
            this.ID = id;
            this.IDUSERGROUP = idUserGroup;
            this.IDREPORT = idReport;
            this.NIVEL = nivel;
        }
        #endregion
    }
}
