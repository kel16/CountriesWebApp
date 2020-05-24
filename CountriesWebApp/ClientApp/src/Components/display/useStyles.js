import { makeStyles } from '@material-ui/styles'

export const useStyles = makeStyles((theme) => ({
	content: {
		display: 'flex',
		flexDirection: 'column',
		alignItems: 'center',
		textAlign: 'left',
	},
	nested: {
		minWidth: '250px',
		padding: theme.spacing(2),
	},
}))
