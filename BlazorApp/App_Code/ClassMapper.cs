﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp {

  public class ClassMapper {

    public string Class {
      get { return AsString(); }
    }

    public string AsString() {
      return string.Join(" ", map.Where(i => i.Value()).Select(i => i.Key()));
      ;
    }

    public override string ToString() {
      return AsString();
    }

    private Dictionary<Func<string>, Func<bool>> map = new Dictionary<Func<string>, Func<bool>>();

    public ClassMapper Add(string name) {
      map.Add(() => name, () => true);
      return this;
    }

    public ClassMapper Get(Func<string> funcName) {
      map.Add(funcName, () => true);
      return this;
    }

    public ClassMapper GetIf(Func<string> funcName, Func<bool> func) {
      map.Add(funcName, func);
      return this;
    }

    public ClassMapper If(string name, Func<bool> func) {
      map.Add(() => name, func);
      return this;
    }

  } //-- END CLASS
} //-- END NAMESPACE
