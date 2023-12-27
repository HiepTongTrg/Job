import { createStore } from 'vuex'
import axios from 'axios'

export default createStore({
  state: {
    jobs: [],
    job:{
      id:'',
      ngayDang:'',
      tenCongViec:'',
      luong:'',
      moTa:'',
      loaiCV:'',
      avatar:null,
      nhaTuyenDungId:''
    },
    companys: [],
    company:{
      id:null,
      tenCongTy:'',
      diaChi:'',
      dienThoai:'',
      email:'',
      userName:'',
      passWord:''
    },
    jobsters: [],
    jobster:{
      id:'',
      tenUngVien:'',
      diaChi:'',
      dienThoai:'',
      email:'',
      userName:'',
      passWord:''
    },
    applys:[],
    apply:{
      id:'',
      cv:null,
      trangThai:0,
      moTa:''
    },
    filteredJobs: [],
    searchQuery: '',
    filters: {
      name1: false,
      name2: false,
      name3: false,
      type1: false,
      type2: false,
      salary1: false,
      salary2: false,
      salary3: false,
    },
    token: null,
    isLoggedIn: false
  },
  getters: {
    jobs: state => state.jobs,
    job: state => state.job,
    companys: state => state.companys,
    company: state => state.company,
    jobsters: state => state.jobsters,
    jobster: state => state.jobster,
    applys: state => state.applys,
    apply: state => state.apply,
    isLoggedIn: state => state.isLoggedIn,
    token: state => state.token
  },
  mutations: {
    setJob(state, jobs){
      state.jobs = jobs;
      state.filteredJobs = jobs;
    },
    updateFilter(state, { filter, value }) {
      state.filters[filter] = value;
    },
    applyFilters(state) {
      state.filteredJobs = state.jobs.filter((job) => {
        const nameFilterPassed = (
          (!state.filters.name1 && !state.filters.name2 && !state.filters.name3) ||
          (state.filters.name1 && job.tenCongViec === 'Full-Stack') ||
          (state.filters.name2 && job.tenCongViec === 'Back-End') ||
          (state.filters.name3 && job.tenCongViec === 'Front-End')
        );
        const typeFilterPassed = (
          (!state.filters.type1 && !state.filters.type2) ||
          (state.filters.type1 && job.loaiCV === 'Full-time') ||
          (state.filters.type2 && job.loaiCV === 'Part-time')
        );
        const salaryFilterPassed = (
          (!state.filters.salary1 && !state.filters.salary2 && !state.filters.salary3) ||
          (state.filters.salary1 && job.luong >= 10000 && job.luong <= 20000) ||
          (state.filters.salary2 && job.luong >= 20000 && job.luong <= 30000) ||
          (state.filters.salary3 && job.luong >= 40000 && job.luong <= 50000)
        );
        const searchQueryPassed = (
          !state.filters.searchQuery ||
          job.tenCongViec.toLowerCase().includes(state.filters.searchQuery.toLowerCase()) ||
          job.loaiCV.toLowerCase().includes(state.filters.searchQuery.toLowerCase())
        );
        return (
          nameFilterPassed &&
          typeFilterPassed &&
          salaryFilterPassed &&
          searchQueryPassed
        );
      });
    },
    getJob(state, job){
      state.job.id = job.id;
      state.job.ngayDang = job.ngayDang;
      state.job.tenCongViec = job.tenCongViec;
      state.job.luong = job.luong;
      state.job.moTa = job.moTa;
      state.job.loaiCV = job.loaiCV;
      state.job.avatar = job.avatar;
      state.job.nhaTuyenDungId = job.nhaTuyenDungId;
    },
    deleteJob(state, id){
      var index = state.jobs.findIndex(m => m.id == id);
      if(index > -1){
        state.jobs.splice(index, 1);
      }
    },
    setCompany(state, companys){
      state.companys = companys
    },
    getCompany(state, company){
      state.company.id = company.id;
      state.company.tenCongTy = company.tenCongTy;
      state.company.diaChi = company.diaChi;
      state.company.dienThoai = company.dienThoai;
      state.company.email = company.email;
      state.company.userName = company.userName;
      state.company.passWord = company.passWord;
    },
    setJobster(state, jobsters){
      state.jobsters = jobsters
    },
    getJobster(state, jobster){
      state.jobster.id = jobster.id;
      state.jobster.tenUngVien = jobster.tenUngVien;
      state.jobster.diaChi = jobster.diaChi;
      state.jobster.dienThoai = jobster.dienThoai;
      state.jobster.email = jobster.email;
      state.jobster.userName = jobster.userName;
      state.jobster.passWord = jobster.passWord;
    },
    addJobster(state, jobster){
      state.jobsters.push(jobster);
    },
    setApplys(state, applys){
      state.applys = applys
    },
    getApply(state, apply){
      state.apply.id = apply.id;
      state.apply.cv = apply.cv;
      state.apply.trangThai = trangThai;
      state.apply.moTa = moTa;
    },
    addApply(state, apply){
      state.applys.push(apply);
    },
    setToken(state, token){
      state.token = token;
      state.isLoggedIn = !!token;
    }
  },
  actions: {
    loadJobs({commit}){
      axios.get('https://localhost:7247/api/CongViec')
      .then(response=>{
        if(response.data){
          commit("setJob", response.data);
        }
      })
      .catch(e=>{
        console.log(e);
      })
    },
    updateFilter({ commit }, { filter, value }) {
      commit('updateFilter', { filter, value });
      commit('applyFilters');
    },
    getJob({commit},id){
      if(id){
        axios.get('https://localhost:7247/api/CongViec' + "/" + id)
        .then(response=>{
          if(response.data){
            commit("getJob", response.data);
          }
        })
        .catch(e=>{
          console.log(e);
        })
      }
    },
    deleteJob({commit},id){
      if(id){
        axios.delete('https://localhost:7247/api/CongViec' + "/" + id)
        .then(response=>{
          if(response.data){
            commit("deleteJob", response.data.id);
          }
        })
        .catch(e=>{
          console.log(e);
        })
      }
    },
    loadCompanys({commit}){
      axios.get('https://localhost:7247/api/NhaTuyenDung')
      .then(response=>{
        if(response.data){
          commit("setCompany", response.data)
        }
      })
      .catch(e=>{
        console.log(e);
      })
    },
    getCompany({commit},id){
      if(id){
        axios.get('https://localhost:7247/api/NhaTuyenDung' + "/" + id)
        .then(response=>{
          if(response.data){
            commit("getCompany", response.data);
          }
        })
        .catch(e=>{
          console.log(e);
        })
      }
    },
    loadJobsters({commit}){
      axios.get('https://localhost:7247/api/UngVien')
      .then(response=>{
        if(response.data){
          commit("setJobster", response.data);
        }
      })
      .catch(e=>{
        console.log(e);
      })
    },
    getJobster({commit},id){
      if(id){
        axios.get('https://localhost:7247/api/UngVien' + "/" + id)
        .then(response=>{
          if(response.data){
            commit("getJobster", response.data);
          }
        })
        .catch(e=>{
          console.log(e);
        })
      }
    },
    addJobster({commit}, jobster){
      axios.post('https://localhost:7247/api/UngVien', jobster)
      .then(response=>{
        if(response.data){
          commit("addJobster", response.data);
        }
      })
      .catch(e=>{
        console.log(e);
      })
    },
    login({commit}, token){
      commit("setToken", token)
    },
    logout({commit}){
      commit("setToken", null)
    }
  },
  modules: {
  }
})
