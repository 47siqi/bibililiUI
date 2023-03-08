const { defineConfig } = require('@vue/cli-service')
module.exports = defineConfig({
  transpileDependencies: true,
  devServer: {
    proxy: {
        '/api': {
            target: 'https://localhost:7210',
            //target:"https://localhost:7210/api/Login/GetValidateCodeImages?t=",
            // 允许跨域
            changeOrigin: true,
            ws: true,
            //pathRewrite: {
            //    '^/api': ''
            //}
        }
    }
}
})
