import React from 'react'
import { Form, Field } from 'react-final-form'
import { Typography, Button } from '@material-ui/core'
import axios from 'axios'

import { TextField } from '../theme'

const AddForm = ({ countryName }) => {
	const required = (value) => (value ? undefined : '*required field*')
	const [submitted, setSubmitted] = React.useState(false)

	const onSubmit = (values, form) => {
		axios({
			method: 'post',
			url: `/api/Countries/add-country`, // https://localhost:5001
			data: values,
		})
			.then(function (response) {
				if (response.status != 200) {
					throw Error(`Response status: ${response.status}`)
				} else {
					setSubmitted(true)
					setTimeout(form.reset)
				}
			})
			.catch(function (error) {
				console.log(error)
			})
	}

	return (
		<Form
			onSubmit={onSubmit}
			initialValues={{
				name: countryName,
			}}
			render={({ handleSubmit, form, submitting, pristine, values }) => (
				<form onSubmit={handleSubmit}>
					<div>
						<Field
							name='name'
							component={TextField}
							type='text'
							label='Название страны'
							disabled
						/>
					</div>
					<div>
						<Field
							name='code'
							component={TextField}
							validate={required}
							type='text'
							label='Код страны'
							warning='Поле обязательно для заполнения'
						/>
					</div>
					<div>
						<Field
							name='square'
							component={TextField}
							validate={required}
							type='number'
							label='Площадь'
							warning='Поле обязательно для заполнения'
						/>
					</div>
					<div>
						<Field
							name='population'
							component={TextField}
							validate={required}
							type='number'
							label='Население'
							warning='Поле обязательно для заполнения'
						/>
					</div>
					<div>
						<Field
							name='region'
							component={TextField}
							validate={required}
							type='text'
							label='Название региона'
							warning='Поле обязательно для заполнения'
						/>
					</div>
					<div>
						<Field
							name='capital'
							component={TextField}
							validate={required}
							type='text'
							label='Название столицы'
							warning='Поле обязательно для заполнения'
						/>
					</div>
					<div>
						{!submitted ? (
							<Button
								variant='outlined'
								color='primary'
								type='submit'
								disabled={submitting || pristine}>
								Отправить
							</Button>
						) : (
							<Typography>Форма отправлена</Typography>
						)}
					</div>
					<pre>{JSON.stringify(values, 0, 2)}</pre>
				</form>
			)}
		/>
	)
}

const Search = () => {
	const [loading, setLoading] = React.useState(true)
	const [error, setError] = React.useState(false)
	const [info, setInfo] = React.useState(null)
	const [searchName, setSearchName] = React.useState('')

	const [openAdd, setOpenAdd] = React.useState(false)

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

	const required = (value) => (value ? undefined : '*required field*')

	const onSubmit = (values) => {
		setOpenAdd(false)
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
						<Typography variant='h4'>Результат:</Typography>
						<Typography>Код страны: {info.code}</Typography>
						<Typography>Название: {info.name}</Typography>
						<Typography>Столица: {info.capital}</Typography>
						<Typography>Регион: {info.region}</Typography>
						<Typography>Площадь: {info.square}</Typography>
						<Typography>Население: {info.population}</Typography>
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
						{openAdd ? <AddForm countryName={searchName} /> : <></>}
					</div>
				)}
			</div>
		</>
	)
}

export default Search
