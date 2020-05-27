import React from 'react'
import { Form, Field } from 'react-final-form'
import { Typography, Button } from '@material-ui/core'
import axios from 'axios'

import { TextField } from '../theme'
import Add from '../add/Add'
import Update from '../update/Update'

const Search = () => {
	const [loading, setLoading] = React.useState(true)
	const [error, setError] = React.useState(false)
	const [info, setInfo] = React.useState(null)
	const [searchName, setSearchName] = React.useState('')

	const [openAdd, setOpenAdd] = React.useState(false)
	const [openUpdate, setOpenUpdate] = React.useState(false)

	const loadInfo = (countryName) => {
		setLoading(true)
		setError(false)
		setInfo(null)
		axios
			.get(`/api/Countries/get-country?name=${countryName}`)
			/*.get(
				`https://localhost:5001/api/Countries/get-country?name=${countryName}`
			)*/
			.then(function (response) {
				if (response.status != 200) {
					setLoading(false)
					setError(true)
				} else {
					setInfo(response.data)
					setLoading(false)
				}
			})
			.catch(function (error) {
				console.log(error)
			})
	}

	const toggleAdd = () => {
		setOpenAdd(!openAdd)
	}

	const toggleUpdate = () => {
		setOpenUpdate(!openUpdate)
	}

	const required = (value) => (value ? undefined : '*required field*')

	const onSubmit = (values) => {
		setOpenAdd(false)
		setOpenUpdate(false)
		setSearchName(values.name)
		loadInfo(values.name)
	}

	return (
		<>
			<Form
				onSubmit={onSubmit}
				render={({ handleSubmit, form, submitting, pristine, values }) => (
					<form onSubmit={handleSubmit}>
						<div>
							<Field
								name='name'
								component={TextField}
								validate={required}
								type='text'
								label='Название страны'
								warning='Поле обязательно для заполнения'
							/>
						</div>
						<div>
							<Button
								variant='outlined'
								color='primary'
								type='submit'
								disabled={submitting || pristine}>
								Искать
							</Button>
						</div>
					</form>
				)}
			/>
			<div>
				{loading ? (
					error ? (
						<Typography>Возникла ошибка</Typography>
					) : (
						<></>
					)
				) : info ? (
					<div>
						<div>
							<Typography variant='h4'>Результат:</Typography>
							{Object.entries(info).map(([key, value]) => (
								<>
									<Typography key={key}>
										{key}: {value}
									</Typography>
								</>
							))}
						</div>
						<div>
							<Typography variant='h4' gutterBottom>
								Хотите внести изменения?
							</Typography>
							<Button
								color='secondary'
								variant='contained'
								onClick={() => toggleUpdate()}>
								{openUpdate ? 'Нет' : 'Да'}
							</Button>
							{openUpdate ? <Update country={info} /> : <></>}
						</div>
					</div>
				) : (
					<div>
						<Typography variant='h4'>
							Не удалось найти страну с таким названием
						</Typography>
						<Typography gutterBottom>Хотите внести страну в БД?</Typography>
						<Button
							color='secondary'
							variant='contained'
							onClick={() => toggleAdd()}>
							{openAdd ? 'Нет' : 'Да'}
						</Button>
						{openAdd ? <Add countryName={searchName} /> : <></>}
					</div>
				)}
			</div>
		</>
	)
}

export default Search
