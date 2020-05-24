import React from 'react'
import { Container, Button, Typography } from '@material-ui/core'
import { useStyles } from './useStyles'
import { Link } from 'react-router-dom'
import axios from 'axios'

const Home = () => {
	const classes = useStyles()
	const [loading, setLoading] = React.useState(true)
	const [error, setError] = React.useState(false)
	const [items, setItems] = React.useState([])

	const loadItems = () => {
		setLoading(true)
		setError(false)
		setItems([])
		axios
			.get(`/api/Countries/get-countries`)
			//.get('https://localhost:5001/api/Countries/get-countries')
			.then(function (response) {
				if (response.status != 200) {
					setLoading(false)
					setError(true)
				} else {
					setItems(response.data)
					setLoading(false)
				}
			})
			.catch(function (error) {
				console.log(error)
			})
	}

	return (
		<Container style={{ textAlign: 'center' }}>
			<Button variant='outlined' onClick={() => loadItems()}>
				Вывести
			</Button>
			<div className={classes.content}>
				{loading ? (
					error ? (
						<Typography>Возникла ошибка</Typography>
					) : (
						<></>
					)
				) : items.length > 0 ? (
					items.map((row) => (
						<div className={classes.nested} key={row.code}>
							<Typography>Код страны: {row.code}</Typography>
							<Typography>Название: {row.name}</Typography>
							<Typography>Столица: {row.capital}</Typography>
							<Typography>Регион: {row.region}</Typography>
							<Typography>Площадь: {row.square}</Typography>
							<Typography>Население: {row.population}</Typography>
						</div>
					))
				) : (
					<Typography>В БД нет стран</Typography>
				)}
			</div>
		</Container>
	)
}

export default Home
