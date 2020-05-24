import React from 'react'
import {
	AppBar,
	Container,
	Box,
	Paper,
	Tab,
	Tabs,
	Typography,
} from '@material-ui/core'
import { useStyles } from './useStyles'

import Display from '../display/Display'
import Search from '../search/Search'

function TabPanel(props) {
	const { children, value, index, ...other } = props

	return (
		<div role='tabpanel' hidden={value !== index} {...other}>
			{value === index && <Box p={3}>{children}</Box>}
		</div>
	)
}

const Home = () => {
	const classes = useStyles()
	const [value, setValue] = React.useState(0)

	const handleChange = (event, newValue) => {
		setValue(newValue)
	}

	return (
		<div className={classes.root}>
			<AppBar position='static' color='default'>
				<Tabs
					value={value}
					onChange={handleChange}
					indicatorColor='primary'
					textColor='primary'
					variant='scrollable'
					scrollButtons='auto'>
					<Tab label='Вывод списка' />
					<Tab label='Поиск' />
				</Tabs>
			</AppBar>
			<TabPanel value={value} index={0}>
				<Display />
			</TabPanel>
			<TabPanel value={value} index={1}>
				<Search />
			</TabPanel>
		</div>
	)
}

export default Home
