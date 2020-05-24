import { makeStyles } from '@material-ui/styles'

export const useStyles = makeStyles((theme) => ({
	root: {
		flexGrow: 1,
		height: '100vh',
		backgroundColor: theme.palette.background.paper,
	},
}))
