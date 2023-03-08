import { createStore } from 'vuex'  //导入vuex
const store = createStore({
  state() {
    return {
      //状态栏
      IsShowLogin: false,  //登录状态
      IsShowRegister: false,  //登录弹窗
      NickName: localStorage["NickName"]//昵称，登录成功后赋值
    }
  },
  //方法
  mutations: {
    OpenLogin(state) {
      state.IsShowLogin = true;
    },
    CloseLogin(state) {
      state.IsShowLogin = false;
    },
    OpenRegister(state) {
      state.IsShowRegister = true;
    },
    CloseRegister(state) {
      state.IsShowRegister = false;
    },
    SettingNickName(state, NickName) {
      state.NickName = NickName;
    }
  }
})
export default store;