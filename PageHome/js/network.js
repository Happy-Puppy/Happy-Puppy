
//var API_URL = 'http://47.100.194.106:81/api/'
var API_URL = 'http://localhost:5000/api/'  

var requestHandler = {
  params: {},
  header: {},
  success: function (res) {
    // success  
  },
  fail: function () {
    // fail  
  },
} 

var requestHandlerBody = {
  params: {},
  header: {},
  Body: '',
  success: function (res) {
    // success  
  },
  fail: function () {
    // fail  
  },
}
 
//GET请求  
function GET(requestHandler) {
  request('GET', requestHandler)
}
//POST请求  
function POST(requestHandler) {
  request('POST', requestHandler)
}
//PUT请求
function PUT(requestHandler){
  request('PUT', requestHandler)
}
//DEL请求
function DEL(requestHandler){
  request('DELETE', requestHandler)
}

function request(method, requestHandler) {
  //注意：可以对params加密等处理  
  var params = requestHandler.params
  var header = requestHandler.header
  var BaseUrl = params.api_url
  delete params.api_url
  $.ajax({
    url: API_URL + BaseUrl,
    data: params.data,
    type: method, // OPTIONS, GET, HEAD, POST, PUT, DELETE, TRACE, CONNECT 
    contentType : "application/json",
    success: function (res) {
      //debugger
      //注意：可以对参数解密等处理  
      //if (res.statusCode == 200 || res.statusCode == 201 || res.statusCode == 204) {
        requestHandler.success(res)
      //}
      //else {
      //  requestHandler.fail(res.data)
      //}
    },
    fail: function (res) {
      debugger
      //requestHandler.fail()
    },
    complete: function (res) {
      //debugger
      // complete  
    }
  })
}  