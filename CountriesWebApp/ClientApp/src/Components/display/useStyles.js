import TableCell from '@material-ui/core/TableCell'
import TableRow from '@material-ui/core/TableRow'
import { withStyles, makeStyles } from '@material-ui/core/styles'

export const useStyles = makeStyles((theme) => ({
	topNavigation: {
		flexGrow: 1,
		backgroundColor: theme.palette.background.default,
	},
	paperTable: {
		width: '100%',
		marginTop: theme.spacing(3),
		marginBottom: theme.spacing(3),
		overflowX: 'auto',
	},
	table: {
		minWidth: 700,
	},
}))

export const StyledTableCell = withStyles((theme) => ({
	head: {
		backgroundColor: theme.palette.common.black,
		color: theme.palette.common.white,
	},
	body: {
		fontSize: 14,
	},
}))(TableCell)

export const StyledTableRow = withStyles((theme) => ({
	root: {
		'&:nth-of-type(odd)': {
			backgroundColor: theme.palette.secondary.light,
		},
	},
}))(TableRow)
