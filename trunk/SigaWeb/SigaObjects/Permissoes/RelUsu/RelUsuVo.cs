using System;
using System.Collections.Generic;
using System.Text;

namespace SigaObjects.Permissoes.RelUsu
{
    public class RelUsuVo
    {
        private int id, idUser, idReport, nivel;

        #region Getters & Setters
        public int ID
        {
            get { return id; }
            set { this.id = value; }
        }
        public int IDUSER
        {
            get { return idUser; }
            set { this.idUser = value; }
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
        public RelUsuVo() { }
        public RelUsuVo(int id)
        {
            this.ID = id;
        }
        public RelUsuVo(int idUser, int idReport, int nivel)
        {
            this.IDUSER = idUser;
            this.IDREPORT = idReport;
            this.NIVEL = nivel;
        }
        public RelUsuVo(int id, int idUser, int idReport, int nivel)
        {
            this.ID = id;
            this.IDUSER = idUser;
            this.IDREPORT = idReport;
            this.NIVEL = nivel;
        }
        #endregion
    }
}
