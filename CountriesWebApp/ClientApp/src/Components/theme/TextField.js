import React from 'react'
import { styled } from '@material-ui/styles'
import TextField from '@material-ui/core/TextField'

const StyledTextField = styled(TextField)(({ theme }) => ({
	margin: theme.spacing(1, 0),
}))

export default ({
	input: { name, onChange, value, ...restInput },
	meta,
	warning,
	...rest
}) => (
	<StyledTextField
		{...rest}
		name={name}
		helperText={meta.error && meta.touched ? warning : undefined}
		error={meta.error && meta.touched}
		InputProps={restInput}
		onChange={onChange}
		value={value}
	/>
)
