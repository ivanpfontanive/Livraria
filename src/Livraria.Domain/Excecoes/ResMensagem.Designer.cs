﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Livraria.Domain.Excecoes {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ResMensagem {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ResMensagem() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Livraria.Domain.Excecoes.ResMensagem", typeof(ResMensagem).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Preenchimento do campo &apos;{0}&apos; é obrigatório!.
        /// </summary>
        public static string MsgCampoObrigatorio {
            get {
                return ResourceManager.GetString("MsgCampoObrigatorio", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Já há um registro com o valor &apos;{0}&apos; cadastrado no sistema!.
        /// </summary>
        public static string MsgRegistroJaExiste {
            get {
                return ResourceManager.GetString("MsgRegistroJaExiste", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Não é possível excluir o registro pois ele possuí dependências!.
        /// </summary>
        public static string MsgRegistroPossuiDependencias {
            get {
                return ResourceManager.GetString("MsgRegistroPossuiDependencias", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Operação realizada com sucesso!.
        /// </summary>
        public static string MsgSucesso {
            get {
                return ResourceManager.GetString("MsgSucesso", resourceCulture);
            }
        }
    }
}