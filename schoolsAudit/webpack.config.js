var webpack = require('webpack');
var path = require('path');

var BUILD_DIR = path.resolve(__dirname, 'build');

console.log('BUILD_DIR: ' + BUILD_DIR);

var APP_DIR = path.resolve(__dirname, 'app');

console.log('APP_DIR: ' + APP_DIR);

var config = {
  entry: APP_DIR + '/app.jsx',
  output: {
    path: BUILD_DIR,
    filename: 'bundle.js',
    publicPath: '/'
  },
  devtool: 'source-map',
  devServer: {
  	contentBase: "./build",
    inline: true,
  	port: 5002
  },
  module: {
  	loaders: [
  		{
        loader : 'babel-loader',
  			test : /\.jsx?/,
        include : APP_DIR,
        query: {
        	presets: ['es2015', 'react']
        }
  		}
  	]
  }
};

module.exports = config;