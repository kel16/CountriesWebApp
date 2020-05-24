import React from 'react'
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom'
import { ThemeProvider } from '@material-ui/styles'
import CssBaseline from '@material-ui/core/CssBaseline'

import { theme } from './theme'
import Home from './home/Home'

function App() {
	return (
		<React.Fragment>
			<CssBaseline />
			<ThemeProvider theme={theme}>
				<Router>
					<Switch>
						<Route path='*' component={Home} />
					</Switch>
				</Router>
			</ThemeProvider>
		</React.Fragment>
	)
}

export default App
