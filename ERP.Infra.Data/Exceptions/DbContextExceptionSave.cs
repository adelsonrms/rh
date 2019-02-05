using System;
using System.Runtime.Serialization;

namespace RH.Infra.Data.DBContexts
{
    [Serializable]
    internal class FcStoreDbContextException : Exception
    {
        public FcStoreDbContextException()
        {
            Ambiente = Shared.Settings.Settings.AmbienteDeExecucao();
        }

        public FcStoreDbContextException(string message) : base(message)
        {
            Ambiente = Shared.Settings.Settings.AmbienteDeExecucao();
        }

        public FcStoreDbContextException(string message, Exception innerException, object envRuntime ) : base(message, innerException)
        {
            Ambiente = Shared.Settings.Settings.AmbienteDeExecucao();
            EnviromentRuntimeMethod = envRuntime;
        }
        protected FcStoreDbContextException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Ambiente = Shared.Settings.Settings.AmbienteDeExecucao();
        }
        public string Ambiente { get; set; }
        public object EnviromentRuntimeMethod { get; set; }
    }
}