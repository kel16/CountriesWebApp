import { createMuiTheme } from '@material-ui/core/styles'
import blueGrey from '@material-ui/core/colors/blueGrey'

const baseTheme = createMuiTheme()

const theme = createMuiTheme({
	...baseTheme,
	'@global': {
		body: {
			height: '100vh',
			width: '100vw',
			padding: 0,
			margin: 0,
		},
	},
	type: 'light',
	overrides: {
		MuiTypography: {
			gutterBottom: {
				marginBottom: baseTheme.spacing(1.5),
			},
		},
		MuiLink: {
			underlineHover: {
				color: 'inherit',
				textDecoration: 'none',
				'&:hover': {
					textDecoration: 'none',
				},
			},
		},
	},
	palette: {
		primary: {
			main: '#263238',
		},
		secondary: {
			main: '#CFD8DC',
		},
		background: {
			default: blueGrey['100'],
		},
	},
	text: {
		primary: '#000',
		secondary: '#fff',
	},
})

export default theme
