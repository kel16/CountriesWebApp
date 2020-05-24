const path = require('path')

module.exports = {
	entry: ['@babel/polyfill', './src/index.js'],
	output: {
		path: path.resolve(__dirname, 'public'),
		filename: 'main.js',
	},
	devtool: 'source-map',
	devServer: {
		contentBase: path.join(__dirname, 'public'),
		compress: true,
		port: 9000,
		historyApiFallback: {
			index: 'public/index.html',
		},
	},
	module: {
		rules: [
			{
				test: /\.js$/,
				exclude: /node_modules/,
				use: {
					loader: 'babel-loader',
					options: {
						presets: ['@babel/preset-env', '@babel/preset-react'],
					},
				},
			},
		],
	},
}
