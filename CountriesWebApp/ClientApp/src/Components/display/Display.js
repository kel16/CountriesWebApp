import React, { useEffect } from 'react'
import {
	Table,
	TableBody,
	TableCell,
	TableHead,
	TableRow,
	TableFooter,
	TablePagination,
	Paper,
	Typography,
	CircularProgress,
} from '@material-ui/core'
import axios from 'axios'

import { useStyles, StyledTableCell, StyledTableRow } from './useStyles'
import TablePaginationActions from './TablePaginationActions'

const Display = () => {
	const classes = useStyles()
	const [page, setPage] = React.useState(0)
	const [total, setTotal] = React.useState(1)
	const [items, setItems] = React.useState({})
	const [loading, setLoading] = React.useState(true)
	const rowsPerPage = 20

	const emptyRows =
		rowsPerPage - Math.min(rowsPerPage, total - page * rowsPerPage)

	function handleChangePage(event, newPage) {
		setPage(newPage)
	}

	useEffect(() => {
		loadItems()
	}, [page])

	const loadItems = () => {
		setLoading(true)
		axios
			.get(
				`/api/Countries/get-countries?page=${page + 1}&quantity=${rowsPerPage}`
			)
			.then(function (response) {
				if (response.status != 200) {
					throw Error(`Response status: ${response.status}`)
				} else {
					setTotal(response.data.total)
					setItems(response.data.countries)
					setLoading(false)
				}
			})
	}

	return (
		<Paper className={classes.paperTable}>
			<Table className={classes.table} aria-label='customized table'>
				{loading ? (
					<>
						<TableHead>
							<TableRow>
								<StyledTableCell></StyledTableCell>
							</TableRow>
						</TableHead>
						<TableBody>
							<StyledTableRow>
								<StyledTableCell component='th' scope='row'>
									<CircularProgress />
								</StyledTableCell>
							</StyledTableRow>
						</TableBody>
					</>
				) : (
					<>
						<TableHead>
							<TableRow>
								{Object.keys(items[0]).map((value) => (
									<StyledTableCell key={value}>
										<Typography>{value}</Typography>
									</StyledTableCell>
								))}
							</TableRow>
						</TableHead>
						<TableBody>
							{items.map((row, index) => (
								<StyledTableRow key={index}>
									{Object.entries(row).map(([key, value]) => (
										<StyledTableCell component='th' scope='row' key={key}>
											<Typography>{value}</Typography>
										</StyledTableCell>
									))}
								</StyledTableRow>
							))}
							{emptyRows > 0 && (
								<TableRow style={{ height: 48 * emptyRows }}>
									<TableCell colSpan={6} />
								</TableRow>
							)}
						</TableBody>
						<TableFooter>
							<TableRow>
								<TablePagination
									count={total}
									rowsPerPage={rowsPerPage}
									rowsPerPageOptions={[]}
									page={page}
									onChangePage={handleChangePage}
									ActionsComponent={TablePaginationActions}
								/>
							</TableRow>
						</TableFooter>
					</>
				)}
			</Table>
		</Paper>
	)
}

export default Display
