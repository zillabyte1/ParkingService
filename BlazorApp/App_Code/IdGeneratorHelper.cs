using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp {

  public static class IdGeneratorHelper {
    
  public static string Generate(string prefix) {

      return prefix + Guid.NewGuid();
    }

  } //-- END CLASS
} //-- END NAMESPACE
